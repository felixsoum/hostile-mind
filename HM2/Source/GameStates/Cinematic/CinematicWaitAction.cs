using System;
using Microsoft.Xna.Framework.Input;

namespace HostileMind
{
    public class CinematicWaitAction : CinematicAction
    {
        private int timeLeft;

        public CinematicWaitAction(int millisecToWait)
        {
            timeLeft = millisecToWait;
        }

        public bool Action()
        {
            timeLeft -= Time.deltaTime;
            return timeLeft <= 0;
        }
    }
}

