using System;

namespace HostileMind
{
    public class CutsceneActorAction : CutsceneAction
    {
        private Actor actor;
        private ActorCommand command;

        public CutsceneActorAction(Actor actor, ActorCommand command)
        {
            this.actor = actor;
            this.command = command;
        }

        public bool Act()
        {
            actor.AddCommand(command);
            return true;
        }
    }
}

