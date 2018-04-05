using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HostileMind
{
	public class MidComaHospitalCutscene : Cutscene
    {
        public override void Create(List<CutsceneAction> list)
        {
            var player = PlayerActor.Instance;
            list.Add(new CutscenePlayerLockAction(true));
            list.Add(new CutsceneDialogAction("Hospital coma cutscene"));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(400, 0)));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(0, 100)));
            list.Add(new CutsceneWaitAction(2000));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(-400, -100)));
            list.Add(new CutscenePlayerLockAction(false));
            list.Add(new CutsceneStateTransitionAction(new HospitalLevel())); 
//            var doctor = doctor;

           
//			list.Add(new CutscenePlayerLockAction(true));
//            list.Add(new CutsceneDialogAction("Logan: KAREN!!!"));
//            list.Add(new CutsceneWaitAction(2000));
//            list.Add(new CutsceneDialogAction("Logan: ...Scott?"));
//            list.Add(new CutsceneWaitAction(2000));
//            list.Add(new CutsceneDialogAction("Scott: Thank god you are okay, partner. We received a call saying\n" +
//                "you got into a car accident on your way to work this morning."));
//            list.Add(new CutsceneWaitAction(2000));
//            list.Add(new CutsceneDialogAction(" Scott: You've been in a coma for a little over a day.\n" +
//                                                        " It's a miracle you didn't sustain any major injuries!"));
//            list.Add(new CutsceneDialogAction("Doctor: How are you feeling, Mr. Reed?"));
//            list.Add(new CutsceneWaitAction(2000));
//            list.Add(new CutsceneDialogAction("Logan: My body feels fine, but my head hurts a little."));
//            list.Add(new CutsceneWaitAction(2000));
//            list.Add(new CutsceneDialogAction("Doctor: Well altough you've had some minor injuruies/n"+
//                                            "you did recieve a major blow to your head."));
//            list.Add(new CutsceneWaitAction(2000));
//
//            list.Add(new CutsceneDialogAction("Logan: how did I get into an accident?\n"+
//                "Why did I …Oh no, the case! I need to go see the chief now"));
//            list.Add(new CutsceneWaitAction(2000));
//
//            list.Add(new CutsceneDialogAction("Scott: Woah Logan, I don't think that's a good idea"));
//            list.Add(new CutsceneWaitAction(2000));
//
//            list.Add(new CutsceneDialogAction("Doctor: Your friend is right, you head may hurt you a little now,\n"+
//                "but the severity of the impact may cause you to slip in"));
//            list.Add(new CutsceneWaitAction(2000));
//
//            list.Add(new CutsceneDialogAction("Doctor: Your friend is right, you head may hurt you a little now,\n" +
//                "but the severity of the impact may cause you to slip in and out of consciousness at any time."));
//            list.Add(new CutsceneWaitAction(2000));
//
//            list.Add(new CutsceneDialogAction("You will need to stay under hospital supervision for at least week,\n" +
//                "but the severity of the impact may cause you to slip in and out of consciousness at any time."));
//            list.Add(new CutsceneWaitAction(2000));
//
//
//
//            list.Add(new CutsceneDialogAction("Well "));
//            list.Add(new CutsceneWaitAction(2000));
//
//
//
//            
//            
//            list.Add(new CutsceneActorAction(doctor, new MoveActorCommand(400, 0)));
//            list.Add(new CutsceneActorAction(doctor, new MoveActorCommand(0, 100)));
//			list.Add(new CutsceneWaitAction(2000));
//            list.Add(new CutsceneActorAction(doctor, new MoveActorCommand(-400, -100)));
//			list.Add(new CutscenePlayerLockAction(false));
			
        }
    }
}

