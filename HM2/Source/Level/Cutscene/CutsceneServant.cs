using System;

namespace HostileMind
{
    public static class CutsceneServant
    {
        public static void Set(Level level, Cutscene cutscene)
        {
            cutscene.Create(level.Cutscene);
        }
    }
}

