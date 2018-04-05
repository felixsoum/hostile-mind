using System;

namespace HostileMind
{
    public abstract class ActorCommand
    {
        public Actor Target { get; set; }
        public abstract bool Act();
        public abstract ActorCommand Clone();
    } 
}

