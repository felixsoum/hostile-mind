using System;

namespace HostileMind
{
    public class CutsceneDialogAction : CutsceneAction
    {
        private string text;
		private int displayTime;

		public CutsceneDialogAction(string text, int displayTime = 0)
        {
            this.text = text;
			this.displayTime = displayTime;
        }

        public bool Act()
        {
			if (displayTime > 0)
				Dialog.SetText(text, displayTime);
			else
				Dialog.SetText(text);
            return true;
        }
    }
}

