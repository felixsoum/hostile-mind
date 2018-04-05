using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class TutorialCutscene2 : Cutscene
    {
        public override void Create(List<CutsceneAction> list)
        {
            list.Add(new CutsceneWaitAction(1000));
            list.Add(new CutsceneDialogAction("Looks like I have work to do... gotta go to the police station"));
        }
    }
}

