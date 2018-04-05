using System;

namespace HostileMind
{
    public class CutsceneRemoveActorAction : CutsceneAction
    {
        private Actor actor;

		public CutsceneRemoveActorAction(Actor actor)
        {
            this.actor = actor;
        }

        public bool Act()
        {
            GameInfo.CurrentRoom.RemoveNpc(actor);
            return true;
        }
    }
}

