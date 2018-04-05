using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
  public class HospitalGirlCutscene : Cutscene
    {
    private Actor sandra;
      


		public HospitalGirlCutscene(Actor sandra)
        {
            this.sandra = sandra;
        }
        
        public new void Create(List<CutsceneAction> list)
        {
            var player = PlayerActor.Instance;
            var StartRoom = RoomPlans.Get(typeof(HospitalLoganStart).Name);  
            
            //player.Position = StartRoom.Find("l1").ToVector();
            sandra.Position = StartRoom.Find("d0").ToVector();

            

            list.Add(new CutscenePlayerLockAction(true));
            list.Add(new CutsceneActorAction(sandra, new MoveActorCommand(0,-100)));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(0,1)));
            list.Add(new CutsceneDialogAction("Logan: Sandra what happened to you?"));
            list.Add(new CutsceneWaitAction(3000));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(StartRoom.Find("l2").ToVector()-player.Position)));
            list.Add(new CutsceneDialogAction("Sandra: What the hell do you think?"));
			list.Add(new CutsceneWaitAction(4000));
            list.Add(new CutsceneDialogAction("Logan: ..."));
            list.Add(new CutsceneWaitAction(2000));
            list.Add(new CutsceneDialogAction("Sandra: I was burned in the fire..."));
            list.Add(new CutsceneWaitAction(2000));
            list.Add(new CutsceneDialogAction("Sandra: That you saved me from...?"));
            list.Add(new CutsceneWaitAction(5000));
            list.Add(new CutsceneDialogAction("Logan: Oh...  right...  I forgot..."));
            list.Add(new CutsceneWaitAction(2000));
            list.Add(new CutsceneDialogAction("Sandra: Oh Logan... There were so many people in the fire.. "));
            list.Add(new CutsceneWaitAction(5000));
            list.Add(new CutsceneDialogAction("Sandra: It was awful... "));
            list.Add(new CutsceneWaitAction(2000));
            list.Add(new CutsceneDialogAction("Sandra: I am hideous now! I don't want to be here anymore!"));
            list.Add(new CutsceneWaitAction(2000));
            list.Add(new CutsceneActorAction(sandra, new MoveActorCommand(StartRoom.Find("d0").ToVector()-sandra.Position)));
            list.Add(new CutsceneRemoveActorAction(sandra));
            list.Add(new CutsceneDialogAction("Logan: Sandra!!"));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(0, 200)));
            list.Add(new CutsceneDialogAction("Logan: ...F*&%"));
            list.Add(new CutsceneWaitAction(2000));   
            list.Add(new CutscenePlayerLockAction(false));
            
        }
  }
}
