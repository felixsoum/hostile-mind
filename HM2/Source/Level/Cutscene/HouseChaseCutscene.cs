using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class HouseChaseCutscene : Cutscene
    {
        public override void Create(List<CutsceneAction> list)
        {
            var player = PlayerActor.Instance;
			list.Add(new CutscenePlayerLockAction(true));
			list.Add(new CutsceneActorAction(player, new MoveActorCommand(4*GameInfo.TILE_X, -6*GameInfo.TILE_Y)));
			list.Add(new CutsceneWaitAction(2000));
            list.Add(new CutsceneDialogAction("Logan: He's fast..."));
			list.Add(new CutscenePlayerLockAction(false));
        }
    }
}

