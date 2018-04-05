using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    public class SandraSprite : Sprite
    {
        public SandraSprite()
            : base(Textures.Get("enemy"), 4, 3)
        {
        }

        public void MoveDown()
        {
            IsFlipped = false;
            AnimateLoop(0, 3);
        }

        public void MoveRight()
        {
            IsFlipped = true;
            AnimateLoop(8, 11);
        }

        public void MoveUp()
        {
            IsFlipped = false;
            AnimateLoop(4, 7);
        }

        public void MoveLeft()
        {
            IsFlipped = false;
            AnimateLoop(8, 11);
        }

        public void StandDown()
        {
            IsFlipped = false;
            SetFrame(3);
        }

        public void StandRight()
        {
            IsFlipped = true;
            SetFrame(11);
        }

        public void StandUp()
        {
            IsFlipped = false;
            SetFrame(7);
        }

        public void StandLeft()
        {
            IsFlipped = false;
            SetFrame(11);
        }
    }
}
