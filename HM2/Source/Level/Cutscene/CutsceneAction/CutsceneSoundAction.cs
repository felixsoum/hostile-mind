using System;

namespace HostileMind
{
    public class CutsceneSoundAction : CutsceneAction
    {
        private CinematicSoundAction action;

        public CutsceneSoundAction(string sound)
        {
            action = new CinematicSoundAction(sound);
        }

        public bool Act()
        {
            return action.Action();
        }
    }
}

