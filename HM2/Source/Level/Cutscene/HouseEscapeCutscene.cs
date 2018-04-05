using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class HouseEscapeCutscene : Cutscene
    {
        private Actor shadow;
        
		public HouseEscapeCutscene(Actor shadow)
        {
            this.shadow = shadow;
        }
        
        public override void Create(List<CutsceneAction> list)
        {
            var player = PlayerActor.Instance;
            list.Add(new CutscenePlayerLockAction(true));
            
            list.Add(new CutsceneWaitAction(2000));
            list.Add(new CutsceneActorAction(shadow, new MoveActorCommand(-5*GameInfo.TILE_X, 0)));
			list.Add(new CutsceneDialogAction("Logan: STOOOP!!!"));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(-5*GameInfo.TILE_X, 0)));
			list.Add(new CutsceneWaitAction(1000));
            list.Add(new CutsceneRemoveActorAction(shadow));
            list.Add(new CutsceneDialogAction("Logan: I'm too late... darn...\nand what the hell was Scott doing there..."));       
			list.Add(new CutsceneWaitAction(2000));

            list.Add(new CutscenePlayerLockAction(false));
            list.Add(new CutsceneStateTransitionAction(new SubwayCinematic()));
        }
    }
}

