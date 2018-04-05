using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class BoundingBox
    {
        public float Left { get; set; }
        public float Top { get; set; }
        public float Right { get; set; }
        public float Bottom { get; set; }

        public Vector2 TopLeft { get { return new Vector2(Left, Top); } }
        public Vector2 TopRight { get { return new Vector2(Right, Top); } }
        public Vector2 BottomLeft { get { return new Vector2(Left, Bottom); } }
        public Vector2 BottomRight { get { return new Vector2(Right, Bottom); } }
        public Vector2 Center { get { return new Vector2((Left + Right) / 2, (Top + Bottom) / 2); } }

        public BoundingBox(float left, float top, float right, float bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public bool Contains(Vector2 point)
        {
            return point.X >= Left
                && point.X <= Right
                && point.Y >= Top
                && point.Y <= Bottom;
        }

        public bool Intersects(BoundingBox otherBox)
        {
            bool condition1 = Contains(otherBox.TopLeft)
                || Contains(otherBox.TopRight)
                || Contains(otherBox.BottomLeft)
                || Contains(otherBox.BottomRight);

            if (condition1)
                return true;

            bool condition2 = otherBox.Contains(TopLeft)
                || otherBox.Contains(TopRight)
                || otherBox.Contains(BottomLeft)
                || otherBox.Contains(BottomRight);

            return condition2;
        }

        public Vector2 GetCollisionResolution(BoundingBox otherBox)
        {
            Vector2 delta = Vector2.Zero;

            // Right collision
            if (Contains(otherBox.TopLeft) || Contains(otherBox.BottomLeft) || otherBox.Contains(TopRight) || otherBox.Contains(BottomRight))
                delta.X = otherBox.Left - Right;
            // Left collision
            else if (Contains(otherBox.TopRight) || Contains(otherBox.BottomRight) || otherBox.Contains(TopLeft) || otherBox.Contains(BottomLeft))
                delta.X = otherBox.Right - Left;

            // Top collision
            if (Contains(otherBox.BottomLeft) || Contains(otherBox.BottomRight) || otherBox.Contains(TopLeft) || otherBox.Contains(TopRight))
                delta.Y = otherBox.Bottom - Top;
            // Bottom collision
            else if (Contains(otherBox.TopLeft) || Contains(otherBox.TopRight) || otherBox.Contains(BottomLeft) || otherBox.Contains(BottomRight))
                delta.Y = otherBox.Top - Bottom;

            return delta;
        }

        public Vector2 GetCollisionResolution(Vector2 point)
        {
            Vector2 delta = Vector2.Zero;

            if (point.X < (Right + Left) / 2)
            {
                delta.X = point.X - Left + 1;
            }
            else
            {
                delta.X = point.X - Right - 1;
            }

            if (point.Y < (Bottom + Top) / 2)
            {
                delta.Y = point.Y - Top + 1;
            }
            else
            {
                delta.Y = point.Y - Bottom - 1;
            }

            return delta;
        }

        public void Draw(Color color)
        {
            Renderer.DrawRectangle(new Rectangle((int)Left, (int)Top, (int)Right - (int)Left, (int)Bottom - (int)Top), color);
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle((int)Left, (int)Top, (int)Right - (int)Left, (int)Bottom - (int)Top);
        }
    }
}