using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class SubwayEndingCutscene : Cutscene
    {
        public override void Create(List<CutsceneAction> list)
        {
            var player = PlayerActor.Instance;

            list.Add(new CutscenePlayerLockAction(true));


            list.Add(new CutsceneWaitAction(3000));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(-4 * GameInfo.TILE_X, 0)));

            list.Add(new CutsceneWaitAction(2000));
            list.Add(new CutsceneDialogAction("Logan: WHAT THE HELL SCOTT!"));
            list.Add(new CutsceneWaitAction(4000));
            list.Add(new CutsceneDialogAction("Scott:  I..He was reaching.. for his ...gun.\nI did what I had to do."));
            list.Add(new CutsceneWaitAction(4000));
            list.Add(new CutsceneDialogAction("Logan: I don't see any gun! You just assumed!"));
            list.Add(new CutsceneWaitAction(4000));
            list.Add(new CutsceneDialogAction("Scott: He took one life, I am sure two more would \nnot have been a problem for him."));
            list.Add(new CutsceneWaitAction(4000));
            list.Add(new CutsceneDialogAction("Logan: Our job is to bring IN the criminals, not take them out. \nWhat you did should have been a last resort!!"));
            list.Add(new CutsceneWaitAction(4000));
            list.Add(new CutsceneDialogAction("Scott: Oh grow up Reed, this was a judgement call, \nand I made it while you were busy sneaking around."));
            list.Add(new CutsceneWaitAction(4000));
            list.Add(new CutsceneStateTransitionAction(new SubwayEndingCinematic()));

            
            

            list.Add(new CutscenePlayerLockAction(false));
        }
        
    }
}
