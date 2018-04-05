using System;
using System.Collections.Generic;

namespace HostileMind
{
    public class Cutscene
    {
        public PersonActor doctor = new PersonActor("npc-doctor");
        public virtual void Create(List<CutsceneAction> list)
        {
        }
    }
}

