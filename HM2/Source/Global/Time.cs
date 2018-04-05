using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public static class Time
    {
        public static int deltaTime;
        public static float deltaTimeSec;
        public static int totalTime;
        private static List<int> deltaTimes = new List<int>();
        private const int FRAMES_SAMPLING_COUNT = 10;

        public static void Set(GameTime gameTime)
        {
            deltaTime = gameTime.ElapsedGameTime.Milliseconds;
            totalTime = (int)gameTime.TotalGameTime.TotalMilliseconds;
            deltaTimeSec = (float)gameTime.ElapsedGameTime.TotalSeconds;
            deltaTimes.Add(deltaTime);
            if (deltaTimes.Count > FRAMES_SAMPLING_COUNT)
                deltaTimes.RemoveAt(0);
        }

        public static int GetFps()
        {
            if (deltaTimes.Count == 0)
                return 0;

            int totalDeltaTimes = 0;
            foreach (int d in deltaTimes)
                totalDeltaTimes += d;

            return 1000 / (totalDeltaTimes / deltaTimes.Count);
        }

        public static void DrawFps()
        {
            Renderer.DrawText(Renderer.shareTechFont, "FPS:" + GetFps(), new Vector2(Renderer.DEFAULT_SCREEN_WIDTH - 128, 32), Color.White);
        }
    }
}

