using System;

namespace HostileMind
{
    public interface OnStepCommand
    {
        void OnStep();
        OnStepCommand Clone();
    }
}

