using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class MoveActorCommand : ActorCommand
    {
        private Vector2 movement;

        public MoveActorCommand(int x, int y)
            : this(new Vector2(x, y))
        {
        }

        public MoveActorCommand(Vector2 movement)
        {
            this.movement = movement;
        }

        public override bool Act()
        {
            if (movement == Vector2.Zero)
                return true;
            var deltaMovement = Vector2.Zero;

			int deltaXMax = (int)(Target.MoveSpeed.X * Time.deltaTime);
			if (Math.Abs(movement.X) < Math.Abs(deltaXMax))
                deltaMovement.X = movement.X;
            else
				deltaMovement.X = Math.Sign(movement.X) * deltaXMax;

			int deltaYMax = (int)(Target.MoveSpeed.Y * Time.deltaTime);
            if (Math.Abs(movement.Y) < Math.Abs(Target.MoveSpeed.Y * Time.deltaTime))
                deltaMovement.Y = movement.Y;
            else
				deltaMovement.Y = Math.Sign(movement.Y) * deltaYMax;

            movement -= deltaMovement;
            Target.Move(deltaMovement);
            return false;
        }

        public override ActorCommand Clone()
        {
            return new MoveActorCommand(movement);
        }
    }
}

