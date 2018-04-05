using System;

namespace HostileMind
{
    public class CinematicSoundAction : CinematicAction
    {
        private string sound;

        public CinematicSoundAction(string sound)
        {
            this.sound = sound;
        }

        public bool Action()
        {
            Sounds.Get(sound).Play();
            return true;
        }
    }
}

