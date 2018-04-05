using System;

namespace HostileMind
{
    public class CinematicImageAction : CinematicAction
    {
        private CinematicState state;
        private Sprite image;

        public CinematicImageAction(CinematicState state, Sprite image)
        {
            this.state = state;
            this.image = image;
        }

        public bool Action()
        {
            state.Image = image;
            return true;
        }
    }
}

