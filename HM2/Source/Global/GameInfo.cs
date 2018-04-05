using System;

namespace HostileMind
{
    public static class GameInfo
    {
        public const int TILE_X = 48;
        public const int TILE_Y = 32;
        public const int SCREEN_BAR_LENGTH = 75;

        public static Level CurrentLevel { get; set; }
        public static Room CurrentRoom { get { return CurrentLevel.CurrentRoom; } }
		public static bool IsPaused { get { return playerLockCount > 0; } }
        public static bool IsGodModeEnabled { get; set; }

        static GameInfo()
        {
            IsGodModeEnabled = false;
        }

		private static int playerLockCount = 0;

		public static void AddPlayerLock()
		{
			playerLockCount++;
		}

		public static void RemovePlayerLock()
		{
			playerLockCount--;
		}

		public static void ClearPlayerLock()
		{
			playerLockCount = 0;
		}
    }
}

