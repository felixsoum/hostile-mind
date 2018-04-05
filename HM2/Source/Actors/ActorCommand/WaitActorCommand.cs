using System;

namespace HostileMind
{
    public class WaitActorCommand : ActorCommand
    {
        private int millisecToWait;

        public WaitActorCommand(int millisecToWait)
        {
            this.millisecToWait = millisecToWait;
        }

        public override bool Act()
        {
            millisecToWait -= Time.deltaTime;
            return millisecToWait <= 0;
        }

        public override ActorCommand Clone()
        {
            return new WaitActorCommand(millisecToWait);
        }
    }
}

