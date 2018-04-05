using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
	public class EnemyActor : Actor
    {

		public const float MOVE_SPEED_X = 0.20f;
		public const float MOVE_SPEED_Y = 0.16f;
		private EnemySprite sprite = new EnemySprite();

		public EnemyAi Ai { get; set; }
        private bool isChasingPlayer = false;
        private const float SPEED_UP = 1.5f;
        private const int SEARCH_RANGE_IN_TILE = 4;

        public EnemyActor()
        {
			MoveSpeed = new Vector2(MOVE_SPEED_X, MOVE_SPEED_Y);
			Ai = new NullAi();
        }
        
        public EnemyActor(EnemyActor enemyActor)
            : base(enemyActor)
        {
            sprite = enemyActor.sprite;
            orientation = enemyActor.orientation;
            Ai = enemyActor.Ai;
            isChasingPlayer = enemyActor.isChasingPlayer;
        }
        
        public override Actor Clone()
        {
            return new EnemyActor(this);
        }

		public override void Update()
		{

            var player = PlayerActor.Instance;
            if (!isChasingPlayer && IsDetecting(player))
            {
                isChasingPlayer = true;
                MoveSpeed *= SPEED_UP;
            }

            Vector2 prePosition = Position;
            if (!isChasingPlayer)
            {
                Ai.Update(this);

                while (Commands.Count > 0)
                {
                    if (Commands[0].Act())
                        Commands.RemoveAt(0);
                    else
                        break;
                }
            }
            else
            {
                if (!GetHitbox().Intersects(player.GetHitbox()))
                    MoveTowards(player.Position);
                else
                {
                    if (!GameDirector.IsTransitioning() && !GameInfo.IsGodModeEnabled)
                    {
                        player.LifeCount--;
                        if (player.LifeCount > 0)
                            GameDirector.TransitionTo(new RetryCinematic(GameInfo.CurrentLevel.Clone()));
                        else
                            GameInfo.CurrentLevel.NotifyLose();
                    }
                }
            }

            // Animation
            if (prePosition == Position)
            {
                AnimateStand();
            }
            else
            {
                SetOrientation(Position - prePosition);
                AnimateMove();
            }
            sprite.Update();
        }

        public override void Draw()
        {
            Vector2 offset = new Vector2(0, -24);
//            GetHitbox().Draw(Color.Magenta * 0.25f);
            sprite.Draw(Position + offset, Light.ToColor(), Depth.GetDepthFromY(Position.Y));
        }

        private bool IsDetecting(Actor actor)
        {
            if (!actor.IsDetectable())
                return false;

            var distance = actor.Position - Position;
            distance.Y *= (float)GameInfo.TILE_Y / GameInfo.TILE_X;
            if (distance.Length() > GameInfo.TILE_X * SEARCH_RANGE_IN_TILE)
                return false;


//            Console.WriteLine("P:" + actor.Position + ", E:" + Position);
            if (GameInfo.CurrentRoom.IsBlockBetween(Position, actor.Position))
                return false;

            var angle = Math.Atan2(actor.Position.Y - Position.Y,
                                   actor.Position.X - Position.X);
            float deltaX = (float)Math.Atan2(GameInfo.TILE_X, GameInfo.TILE_Y);
            switch (orientation)
            {
                case Orientation.DOWN:
                    return angle > MathHelper.PiOver2 - deltaX && angle < MathHelper.PiOver2 + deltaX;
                case Orientation.RIGHT:
                    return angle > - (MathHelper.PiOver2 - deltaX) && angle < (MathHelper.PiOver2 - deltaX);
                case Orientation.UP:
                    return angle < -MathHelper.PiOver2 + deltaX && angle > -MathHelper.PiOver2 - deltaX;
                case Orientation.LEFT:
                    return ((angle > MathHelper.Pi - (MathHelper.PiOver2 - deltaX))
                        && (angle <= MathHelper.Pi))
                        || ((angle < (MathHelper.PiOver2 - deltaX) - MathHelper.Pi)
                        && (angle >= -MathHelper.Pi));
            }
            return false;
        }

		private void AnimateStand()
		{
			switch (orientation)
			{
				case Orientation.DOWN:
					sprite.StandDown();
					break;
				case Orientation.RIGHT:
					sprite.StandRight();
					break;
				case Orientation.UP:
					sprite.StandUp();
					break;
				case Orientation.LEFT:
					sprite.StandLeft();
					break;
			}
		}

		private void AnimateMove()
		{
			switch (orientation)
			{
				case Orientation.DOWN:
					sprite.MoveDown();
					break;
				case Orientation.RIGHT:
					sprite.MoveRight();
					break;
				case Orientation.UP:
					sprite.MoveUp();
					break;
				case Orientation.LEFT:
					sprite.MoveLeft();
					break;
			}
		}

		private void SetOrientation(Vector2 movement)
		{
			if (movement.Y > 0)
				orientation = Orientation.DOWN;
			else if (movement.Y < 0)
				orientation = Orientation.UP;
			else if (movement.X > 0)
				orientation = Orientation.RIGHT;
			else if (movement.X < 0)
				orientation = Orientation.LEFT;
		}
    }
}

