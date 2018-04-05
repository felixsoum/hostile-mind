using System;

namespace HostileMind
{
    public class CutsceneStateTransitionAction : CutsceneAction
    {
        private GameState state;

        public CutsceneStateTransitionAction(Level level)
            : this(new LevelState(level))
        {
        }

        public CutsceneStateTransitionAction(GameState state)
        {
            this.state = state;
        }

        public bool Act()
        {
            GameDirector.TransitionTo(state);
            return false;
        }
    }
}

