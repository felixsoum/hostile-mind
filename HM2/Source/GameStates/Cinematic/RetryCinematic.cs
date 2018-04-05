using System;

namespace HostileMind
{
    public class RetryCinematic : CinematicState
    {
        private Level level;

        public RetryCinematic(Level level)
        {
            this.level = level;
        }

        public override void Load()
        {
            base.Load();
            AddWait(500);
            AddText("Is this really what happened...?\nLet's try to remember again...");
            AddWait(500);
        }

        protected override void OnEnd()
        {
            GameDirector.TransitionTo(level);
        }    
    }
}

