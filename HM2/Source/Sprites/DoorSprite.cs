using System;

namespace HostileMind
{
    public class DoorSprite : Sprite
    {
        public enum Orientation
        {
            DOWN,
            LEFT,
            UP,
            RIGHT
        }

        public DoorSprite(string texture, Orientation orientation)
            : base(Textures.Get(texture), 4, 1)
        {
            SetFrame((int)orientation);
        }

        public DoorSprite(Orientation orientation)
            : base(Textures.Get("door-wood"), 4, 1)
        {
            SetFrame((int)orientation);
        }
    }
}

