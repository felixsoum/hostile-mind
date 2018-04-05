using System;

namespace HostileMind
{
    public class CinematicTextAction : CinematicAction
    {
        private CinematicState state;
        private string text;

        public CinematicTextAction(CinematicState state, string text)
        {
            this.state = state;
            this.text = text;
        }

        public bool Action()
        {
            state.Text = text;
            return true;
        }
    }
}

