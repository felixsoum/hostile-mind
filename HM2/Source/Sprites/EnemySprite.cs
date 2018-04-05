using System;

namespace HostileMind
{
	public class EnemySprite : Sprite
    {
        public EnemySprite()
			: base(Textures.Get("npc-gang"), 12, 2)
        {
        }

        public void MoveDown()
        {
            IsFlipped = false;
            AnimateLoop(0, 3);
        }

        public void MoveRight()
        {
            IsFlipped = false;
            AnimateLoop(4, 7);
        }

        public void MoveUp()
        {
            IsFlipped = false;
            AnimateLoop(8, 11);
        }

        public void MoveLeft()
        {
            IsFlipped = true;
            AnimateLoop(4, 7);
        }

        public void StandDown()
        {
            IsFlipped = false;
            AnimateLoop(12, 15);
        }

        public void StandRight()
        {
            IsFlipped = false;
            AnimateLoop(16, 19);
        }

        public void StandUp()
        {
            IsFlipped = false;
            AnimateLoop(20, 23);
        }

        public void StandLeft()
        {
            IsFlipped = true;
            AnimateLoop(16, 19);
        }
    }
}

