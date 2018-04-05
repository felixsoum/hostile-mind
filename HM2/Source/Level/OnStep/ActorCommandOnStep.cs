using System;

namespace HostileMind
{
    public class ActorCommandOnStep : OnStepCommand
    {
        private Actor actor;
        private ActorCommand command;
        bool isSingleCommand;

        public ActorCommandOnStep(Actor actor, ActorCommand command, bool isSingleCommand = true)
        {
            this.actor = actor;
            this.command = command;
            this.isSingleCommand = isSingleCommand;
        }

        public void OnStep()
        {
            if (isSingleCommand && actor.Commands.Count > 0)
                return;

            actor.AddCommand(command.Clone());
        }

        public OnStepCommand Clone()
        {
            return new ActorCommandOnStep(actor, command, isSingleCommand);
        }
    }
}

