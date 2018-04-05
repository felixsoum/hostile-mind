using System;

namespace HostileMind
{
	public class StateTransitionOnStep : OnStepCommand
    {
		private GameState state;

		public StateTransitionOnStep(GameState state)
        {
			this.state = state;
        }

		public void OnStep()
		{
			GameDirector.TransitionTo(state);
		}

        public OnStepCommand Clone()
        {
            var clone = new StateTransitionOnStep(state);
            return clone;
        }
    }
}

