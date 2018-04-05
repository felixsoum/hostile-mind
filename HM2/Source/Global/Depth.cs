using System;

namespace HostileMind
{
    public static class Depth
    {
        public const float INVENTORY = 0.4f;
        private const float GAME_OBJECT_UPPER_BOUND = 0.5f;
        private const float GAME_OBJECT_LOWER_BOUND = 0.6f;
        public const float FLOOR_ITEM = 0.61f;
        public const float FLOOR_HIGHLIGHT = 0.62f;
        public const float FLOOR = 0.63f;

        public static float GetDepthFromY(float y)
        {
            if (y <= 0)
                return 1.0f;

            return GAME_OBJECT_UPPER_BOUND + (GAME_OBJECT_LOWER_BOUND - GAME_OBJECT_UPPER_BOUND)/(y + 1.0f);
        }
    }
}

