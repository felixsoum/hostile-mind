using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class HouseAidCutscene : Cutscene
    {
        public override void Create(List<CutsceneAction> list)
        {
            var player = PlayerActor.Instance;
			list.Add(new CutscenePlayerLockAction(true));
			list.Add(new CutsceneActorAction(player, new MoveActorCommand(0, 6*GameInfo.TILE_Y)));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(5*GameInfo.TILE_X, 0)));
			list.Add(new CutsceneWaitAction(2000));
            list.Add(new CutsceneDialogAction("Logan: She's still breathing...\nI better go find first aid items"));
            list.Add(new CutsceneWaitAction(1000));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(-9*GameInfo.TILE_X, 0)));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(0, -2*GameInfo.TILE_Y)));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(-GameInfo.TILE_X, 0)));
			list.Add(new CutscenePlayerLockAction(false));
        }
    }
}

