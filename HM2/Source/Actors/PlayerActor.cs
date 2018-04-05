using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace HostileMind
{
    public class PlayerActor : Actor
    {
        public static PlayerActor Instance { get; private set; }
        public const float MOVE_SPEED_X = 0.25f;
        public const float MOVE_SPEED_Y = 0.2f;
        private float ACTION_RANGE_X { get { return GameInfo.TILE_X / 1.5f; } }
        private float ACTION_RANGE_Y { get { return GameInfo.TILE_Y / 1.5f; } }

        private SoundEffect stepsSound;
        private PlayerSprite sprite = new PlayerSprite();
        private const int TIME_PLAY_STEPS = 200;
        private int timeSpentMoving = 0;
        public int LifeCount { get; set; }

        private PlayerActor()
        {
            stepsSound = Sounds.Get("steps");
			MoveSpeed = new Vector2(MOVE_SPEED_X, MOVE_SPEED_Y);
            LifeCount = 3;
        }

		public override Actor Clone()
		{
			return Instance;
		}

        public static void Init()
        {
            Instance = new PlayerActor(); 
        }

		public override void Update()
        {
			Vector2 prePosition = Position;
			if (!GameInfo.IsPaused && Commands.Count == 0)
			{
				DoActionOnTile();
                Move(GetMovementInput());
			}

			while (Commands.Count > 0)
			{
				if (Commands[0].Act())
					Commands.RemoveAt(0);
				else
					break;
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

        public void Reset()
        {
            Commands.Clear();
        }

        public void CompleteReset()
        {
            Commands.Clear();
            LifeCount = 3;
        }

		public override void OnMovement(Vector2 movement)
		{
			if (movement != Vector2.Zero)
				timeSpentMoving += Time.deltaTime;
			else
				timeSpentMoving = 0;

			if (timeSpentMoving > TIME_PLAY_STEPS)
			{
				timeSpentMoving -= TIME_PLAY_STEPS;
				stepsSound.Play();
			}
		}

        private Vector2 GetMovementInput()
        {
            Vector2 movement = Vector2.Zero;

            if (Inputs.IsDown(Keys.Down))
                movement.Y += MoveSpeed.Y * Time.deltaTimeSec * 1500;

            if (Inputs.IsDown(Keys.Right))
                movement.X += MoveSpeed.X * Time.deltaTimeSec * 1500;

            if (Inputs.IsDown(Keys.Up))
                movement.Y -= MoveSpeed.Y * Time.deltaTimeSec * 1500;

            if (Inputs.IsDown(Keys.Left))
                movement.X -= MoveSpeed.X * Time.deltaTimeSec * 1500;

            return movement;
        }

        private void DoActionOnTile()
        {
            if (Inputs.IsPressed(Keys.Space))
            {
                var actionPoint = Position;
                switch (orientation)
                {
                    case Orientation.LEFT:
                        actionPoint.X -= ACTION_RANGE_X;
                        break;
                    case Orientation.RIGHT:
                        actionPoint.X += ACTION_RANGE_X;
                        break;
                    case Orientation.UP:
                        actionPoint.Y -= ACTION_RANGE_Y;
                        break;
                    case Orientation.DOWN:
                        actionPoint.Y += ACTION_RANGE_Y;
                        break;
                }

                var room = GameInfo.CurrentRoom;
                if (!room.IsWithinRoom(actionPoint))
                    return;

                var targetTile = room.GetTile(actionPoint);

                // TODO: Better condition verification
                if (targetTile.Floor != null && targetTile.OccupantBlock != null)
                    targetTile.OccupantBlock.OnPlayerAction(orientation);
            }
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

