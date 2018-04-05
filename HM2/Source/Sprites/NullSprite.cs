using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class NullSprite : Sprite
    {
        public static NullSprite Instance
        {
            get
            {
                if (instance == null)
                    instance = new NullSprite();
                return instance;
            }
        }

        private static NullSprite instance = null;

        private NullSprite()
            : base(Textures.Get("white"))
        {
        }

        public override void Update()
        {
        }

        public override void Draw(Vector2 pos, Color color, float depth)
        {
        }

    }
}

