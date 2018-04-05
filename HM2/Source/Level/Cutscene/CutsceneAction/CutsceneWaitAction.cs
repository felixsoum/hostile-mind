using System;

namespace HostileMind
{
    public class CutsceneWaitAction : CutsceneAction
    {
        private CinematicWaitAction action;

        public CutsceneWaitAction(int millisecToWait)
        {
            action = new CinematicWaitAction(millisecToWait);
        }

        public bool Act()
        {
            return action.Action();
        }
    }
}

