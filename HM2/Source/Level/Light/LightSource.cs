using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class LightSource
    {
        private Vector2 Position { get; set; }
        public float Radius { get; set; }
        private float intensity;
        private bool on = true;

        public LightSource(Vector2 position, float radius, float intensity = 1.0f)
        {
            Position = position;
            Radius = radius;
            this.intensity = intensity;
        }
        
        public LightSource Clone()
        {
			return new LightSource(Position, Radius, intensity);
        }

        public Vector2 getPosition()
        {
            return Position;
        }

        public bool getOn()
        {
            return on;
        }

        public void toggleLightSource()
        {
            if (on)
            {
                on = false;
            }
            else
            {
                on = true;
            }
        }

        public void toggleLightSource(bool l)
        {
            on = l;
        }

        public float CalculateIntensity(Vector2 target)
        {
            Vector2 distance = target - Position;
            distance.Y *= (float)GameInfo.TILE_X / GameInfo.TILE_Y;
            float ratio = distance.Length() / (Radius * GameInfo.TILE_X);
            if (ratio > 1f)
                return 0;

            return Fluctuate(1f - ratio*ratio)*intensity;
        }

        private float Fluctuate(float value)
        {
            float flux = (float)Math.Cos(Time.totalTime / 500.0) / 2.0f + 0.5f;
            float result = value * (0.8f + flux*0.2f);
            return result;
        }
    }
}

