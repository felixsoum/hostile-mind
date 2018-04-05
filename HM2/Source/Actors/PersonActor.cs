using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class PersonActor : Actor
    {

        public const float MOVE_SPEED_X = 0.25f;
        public const float MOVE_SPEED_Y = 0.2f;
        private PersonSprite sprite;


        public PersonActor(string texture)
        {
            sprite = new PersonSprite(texture);
            MoveSpeed = new Vector2(MOVE_SPEED_X, MOVE_SPEED_Y);
        }

        public override Actor Clone()
        {
            return null;
        }

        public override void Update()
        {
            Vector2 prePosition = Position;

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

