using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class WifeCutscene : Cutscene
    {
        private Actor shadow;
        
        public WifeCutscene(Actor shadow)
        {
            this.shadow = shadow;
        }
        
        public override void Create(List<CutsceneAction> list)
        {
            var player = PlayerActor.Instance;
            list.Add(new CutscenePlayerLockAction(true));
            
            list.Add(new CutsceneWaitAction(1000));
            // bang
            list.Add(new CutsceneSoundAction("gun-shot"));
			list.Add(new CutsceneDialogAction("Logan: !!!"));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(0, -4*GameInfo.TILE_Y)));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(2*GameInfo.TILE_X, 0)));
			list.Add(new CutsceneWaitAction(1000));
            // bang
            list.Add(new CutsceneSoundAction("gun-shot"));
            list.Add(new CutsceneDialogAction("Logan: Karen!!!"));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(GameInfo.TILE_X, 0)));
            
            // entered room
            list.Add(new CutsceneWaitAction(1000));
            list.Add(new CutsceneActorAction(shadow, new MoveActorCommand(0, -9*GameInfo.TILE_Y)));
            list.Add(new CutsceneActorAction(shadow, new MoveActorCommand(-3*GameInfo.TILE_X, 0)));
            list.Add(new CutsceneActorAction(shadow, new MoveActorCommand(0, -3*GameInfo.TILE_Y)));
            list.Add(new CutsceneWaitAction(1000));
            list.Add(new CutsceneDialogAction("Logan: STOP RIGHT THERE"));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(4*GameInfo.TILE_X, -4*GameInfo.TILE_Y)));
			list.Add(new CutsceneWaitAction(1500));
            list.Add(new CutsceneRemoveActorAction(shadow));
            
            list.Add(new CutscenePlayerLockAction(false));
        }
    }
}

