using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class TutorialCutscene1 : Cutscene
    {
        public override void Create(List<CutsceneAction> list)
        {
            list.Add(new CutsceneWaitAction(4000));
            list.Add(new CutsceneDialogAction("<<Use arrow keys to move Logan around>>"));
            list.Add(new CutsceneWaitAction(4000));
            list.Add(new CutsceneDialogAction("\n<<Use SPACE in front of objects to interact with them>>"));
        }
    }
}

