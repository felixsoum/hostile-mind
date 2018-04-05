using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HostileMind
{
    public class Sprite
    {
        public int MillisecPerFrame { get; set; }
        public delegate void DelegateOnAnimationEnd(int frame);
        public DelegateOnAnimationEnd OnAnimationEnd = delegate {};
        public bool IsFlipped { get; set; }
        public float Scale { get; set; }
        public float Rotation { get; set; }
        private const int DEFAULT_MILLISEC_PER_FRAME = 67;
        private Texture2D texture;
        private Rectangle bounds;
        private int columnCount;
        private int rowCount;
        private int currentFrame = 0;
        private int deltaFrameTime = DEFAULT_MILLISEC_PER_FRAME;
        private int frameStart = 0;
        private int frameEnd = 0;
        private int frameReset = 0;
        private bool isAnimationLooping = true;
        private Vector2 origin = Vector2.Zero;

        public Sprite(Sprite sprite) : this(sprite.texture, sprite.columnCount, sprite.rowCount)
        {
            currentFrame = sprite.currentFrame;
            frameStart = sprite.frameStart;
            frameEnd = sprite.frameEnd;
            frameReset = sprite.frameReset;

            isAnimationLooping = sprite.isAnimationLooping;
            SetBoundsToFrame();
        }

        public Sprite(Texture2D texture) : this(texture, 1, 1)
        {
        }

        public Sprite(Texture2D texture, int columnCount, int rowCount)
        {
            this.texture = texture;
            this.columnCount = columnCount;
            this.rowCount = rowCount;

            MillisecPerFrame = DEFAULT_MILLISEC_PER_FRAME;

            bounds = new Rectangle(0, 0, texture.Width / columnCount, texture.Height / rowCount);
            frameEnd = columnCount * rowCount - 1;
            IsFlipped = false;
            Scale = 1f;
            Rotation = 0;
            SetBoundsToFrame();
        }

        public virtual void Update()
        {
            deltaFrameTime -= Time.deltaTime;
            if (deltaFrameTime > 0)
                return;

            deltaFrameTime = MillisecPerFrame;

            SetNextFrame();
            SetBoundsToFrame();
        }

        public virtual void Draw(Vector2 position)
        {
            Draw(position, Depth.GetDepthFromY(position.Y));
        }

        public virtual void Draw(Vector2 position, Color color)
        {
            Draw(position, color, Depth.GetDepthFromY(position.Y));
        }

        public virtual void Draw(Vector2 position, float depth)
        {
            Draw(position, Color.White, depth);
        }

        public virtual void Draw(Vector2 position, Color color, float depth)
        {
            var effect = IsFlipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Renderer.spriteBatch.Draw(texture, position, bounds, color, Rotation, origin, Scale, effect, depth);
        }

        public void AnimateLoop(int frameStart, int frameEnd)
        {
            this.frameStart = frameStart;
            this.frameEnd = frameEnd;
            this.frameReset = frameStart;
            if (currentFrame < frameStart || currentFrame > frameEnd)
            {
                deltaFrameTime = MillisecPerFrame;
                currentFrame = frameStart;
            }
            isAnimationLooping = true;
            SetBoundsToFrame();
        }

        public void AnimateOnce(int frameStart, int frameEnd, int frameReset)
        {
            this.frameStart = frameStart;
            this.frameEnd = frameEnd;
            this.frameReset = frameReset;
            deltaFrameTime = MillisecPerFrame;
            currentFrame = frameStart;
            isAnimationLooping = false;
            SetBoundsToFrame();
        }

        public void SetFrame(int frame)
        {
            currentFrame = frame;
            frameStart = frame;
            frameEnd = frame;
            frameReset = frame;
            isAnimationLooping = false;
            SetBoundsToFrame();
        }

        private void SetNextFrame()
        {
            if (++currentFrame <= frameEnd)
                return;

            if (!isAnimationLooping)
            {
                frameStart = frameReset;
                frameEnd = frameReset;
                OnAnimationEnd(frameReset);
            }

            currentFrame = frameStart;
        }

        private void SetBoundsToFrame()
        {
            bounds.X = (currentFrame % columnCount) * bounds.Width;
            bounds.Y = (currentFrame / columnCount) * bounds.Height;
            origin.X = bounds.Width / 2f;
            origin.Y = bounds.Height / 2f;
        }

        public int GetFrameWidth()
        {
            return bounds.Width;
        }

        public int GetFrameHeight()
        {
            return bounds.Height;
        }
    }
}

