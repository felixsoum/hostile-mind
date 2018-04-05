using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class Lighting
    {
        private float DEFAULT_INTENSITY = 0.33f;
        public float Intensity
        {
            get
            {
                return intensity;
            }

            set
            {
                intensity = MathHelper.Clamp(value, 0, 1f);
            }
        }
        private float intensity = 1f;

        public Color ToColor()
        {
            return new Color(intensity, intensity, intensity);
        }

        public void Maximize()
        {
            intensity = 1.0f;
        }

        public void Minimize()
        {
            intensity = DEFAULT_INTENSITY;
        }
    }
}

