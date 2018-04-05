using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class MidComaHouseCutscene : Cutscene
    {
        public override void Create(List<CutsceneAction> list)
        {
            var player = PlayerActor.Instance;
			list.Add(new CutscenePlayerLockAction(true));
			list.Add(new CutsceneDialogAction("House coma cutscene"));
			list.Add(new CutsceneActorAction(player, new MoveActorCommand(400, 0)));
			list.Add(new CutsceneActorAction(player, new MoveActorCommand(0, 100)));
			list.Add(new CutsceneWaitAction(2000));
			list.Add(new CutsceneActorAction(player, new MoveActorCommand(-400, -100)));
			list.Add(new CutscenePlayerLockAction(false));
            list.Add(new CutsceneStateTransitionAction(new HouseLevel()));
        }
    }
}

