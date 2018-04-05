using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public abstract class Actor
    {
        public enum Orientation
        {
            DOWN,
            RIGHT,
            UP,
            LEFT
        }
        public List<ActorCommand> Commands { get; set; }
		public Vector2 Position { get; set; }
        public Vector2 MoveSpeed { get; set; }
        public Lighting Light { get; set; }
		public abstract void Update();
		public abstract void Draw();
        protected Orientation orientation = Orientation.DOWN;

        public Actor()
        {
            Commands = new List<ActorCommand>();
            Position = Vector2.Zero;
            Light = new Lighting();
        }
        
        public Actor(Actor actor)
        {
            Commands = new List<ActorCommand>();
            Position = actor.Position;
            MoveSpeed = actor.MoveSpeed;
            Light = actor.Light;
        }

        public void AddCommand(ActorCommand command)
        {
            command.Target = this;
            Commands.Add(command);
        }

        public void MoveTowards(Vector2 target)
        {
            var movement = target - Position;
            var deltaMovement = Vector2.Zero;

            int deltaXMax = (int)(MoveSpeed.X * Time.deltaTime);
            if (Math.Abs(movement.X) < Math.Abs(deltaXMax))
                deltaMovement.X = movement.X;
            else
                deltaMovement.X = Math.Sign(movement.X) * deltaXMax;

            int deltaYMax = (int)(MoveSpeed.Y * Time.deltaTime);
            if (Math.Abs(movement.Y) < Math.Abs(MoveSpeed.Y * Time.deltaTime))
                deltaMovement.Y = movement.Y;
            else
                deltaMovement.Y = Math.Sign(movement.Y) * deltaYMax;
            Move(deltaMovement);
        }

        public void Move(Vector2 movement)
        {
            Position += movement;
			Position = new Vector2((int)Position.X, (int)Position.Y);
            OnMovement(movement);
        }

        public bool IsDetectable()
        {
            return Light.Intensity > 0.5f;
        }

        public BoundingBox GetHitbox()
        {
            return new BoundingBox(Position.X - GameInfo.TILE_X / 2,
                                   Position.Y - GameInfo.TILE_Y / 2,
                                   Position.X + GameInfo.TILE_X / 2 - 1 ,
                                   Position.Y + GameInfo.TILE_Y / 2 - 1);
        }
        
		public abstract Actor Clone();

		public virtual void OnMovement(Vector2 movement)
		{
		}

        public void Orient(Orientation o)
        {
            orientation = o;
        }
    }
}

