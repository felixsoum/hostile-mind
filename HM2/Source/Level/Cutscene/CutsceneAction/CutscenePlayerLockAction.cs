using System;

namespace HostileMind
{
	public class CutscenePlayerLockAction : CutsceneAction
    {
		private bool isLock;

		public CutscenePlayerLockAction(bool isLock)
        {
			this.isLock = isLock;
        }

		public bool Act()
		{
			if (isLock)
				GameInfo.AddPlayerLock();
			else
				GameInfo.RemovePlayerLock();
			return true;
		}
    }
}

