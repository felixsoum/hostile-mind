using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class SubwayStartCutscene : Cutscene
    {
        public override void Create(List<CutsceneAction> list)
        {
            var player = PlayerActor.Instance;

            list.Add(new CutscenePlayerLockAction(true));

            list.Add(new CutsceneWaitAction(2000));
            list.Add(new CutsceneDialogAction("Logan: This place looks like a metro station. And it's past 1 AM. \nNo metro cars are going to pass anymore. The police... "));
            list.Add(new CutsceneWaitAction(5000));
            list.Add(new CutsceneDialogAction("did something happen here?"));
            list.Add(new CutsceneWaitAction(2000));
            list.Add(new CutsceneActorAction(player, new MoveActorCommand(6 * GameInfo.TILE_X, 1 * GameInfo.TILE_Y)));
            list.Add(new CutsceneWaitAction(3000));
            list.Add(new CutsceneDialogAction("Officer: Hey Logan, glad you could make it on time."));
            list.Add(new CutsceneWaitAction(3000));
            list.Add(new CutsceneDialogAction("Officer: If you didn't hear it yet, a homeless man was murdered \nby a gang as an initiation."));
            list.Add(new CutsceneWaitAction(5000));
            list.Add(new CutsceneDialogAction("Officer: The man is dead, unfortunately. But the gang has escaped \ninto the tunnels. We can still catch up to them."));
            list.Add(new CutsceneWaitAction(4000));
            list.Add(new CutsceneDialogAction("Officer: ..."));
            list.Add(new CutsceneWaitAction(2000));
            list.Add(new CutsceneDialogAction("Officer: That\'s right! I almost forgot. \nYou were assigned a new partner today weren't you?"));
            list.Add(new CutsceneWaitAction(4000));
            list.Add(new CutsceneDialogAction("Officer: He's waiting for you at the metro platform."));
            list.Add(new CutsceneWaitAction(3000));
            list.Add(new CutsceneDialogAction("Officer: I think his name was Scott..."));

//            list.Add(new CutsceneWaitAction(4000));
//            list.Add(new CutsceneDialogAction("I remember now. It's that day I met and partnered with \nScott for the first time, 10 years ago."));
//            list.Add(new CutsceneWaitAction(4000));
//            list.Add(new CutsceneActorAction(player, new MoveActorCommand(2 * GameInfo.TILE_X, 5 * GameInfo.TILE_Y)));
//            list.Add(new CutsceneActorAction(player, new MoveActorCommand(3*GameInfo.TILE_X, 0)));
//            list.Add(new CutsceneActorAction(player, new MoveActorCommand(4 * GameInfo.TILE_X, 0)));
//            list.Add(new CutsceneWaitAction(2000));
//            list.Add(new CutsceneDialogAction("Scott: Ah, you must be Reed, my new partner? \nI'm Scott Connors."));
//            list.Add(new CutsceneWaitAction(4000));
//            list.Add(new CutsceneDialogAction("Logan: Good to meet you, you can just call me Logan."));
//            list.Add(new CutsceneWaitAction(4000));
//            list.Add(new CutsceneDialogAction("Scott: Alright Logan, looks like we got ourselves a murder."));
//            list.Add(new CutsceneWaitAction(4000));
//            list.Add(new CutsceneDialogAction("Scott: Homeless man shot dead by a gang member."));
//            list.Add(new CutsceneWaitAction(4000));
//            list.Add(new CutsceneDialogAction("Scott: The shooter and the rest and the gang escaped through the \ntunnels, but they won't make it far. I'll make sure of that."));
//            list.Add(new CutsceneWaitAction(5500));
//            list.Add(new CutsceneDialogAction("Logan: Why are you smiling? A man was murdered, \nthis isn't a game."));
//            list.Add(new CutsceneWaitAction(5300));
//            list.Add(new CutsceneDialogAction("Scott: Huh? Oh come on, it's just the thrill of the chase. \nAnyway, we are wasting time."));
//            list.Add(new CutsceneWaitAction(5000));
//            list.Add(new CutsceneDialogAction("Scott: There are two witnesses: the janitor and the maintenance \nman over there."));
//            list.Add(new CutsceneWaitAction(5000));
//            list.Add(new CutsceneDialogAction("Scott: We should go talk to them."));
//            list.Add(new CutsceneWaitAction(3000));
//            list.Add(new CutsceneDialogAction("Logan: Right."));
//
//            list.Add(new CutsceneWaitAction(2000));
//            list.Add(new CutsceneActorAction(player, new MoveActorCommand(0, 4 * GameInfo.TILE_Y)));
//            list.Add(new CutsceneActorAction(player, new MoveActorCommand(GameInfo.TILE_X, GameInfo.TILE_Y)));
//            player.Orient(Actor.Orientation.DOWN);
//
//            list.Add(new CutsceneWaitAction(2000));
//            list.Add(new CutsceneDialogAction("Janitor: I was at the other end of the station, \nbut I saw it happen."));
//            list.Add(new CutsceneWaitAction(5000));
//            list.Add(new CutsceneDialogAction("Janitor: Kid raised the gun and shot the hobo. \nWhat the hell is this world coming to?"));
//            list.Add(new CutsceneWaitAction(5000));
//            list.Add(new CutsceneDialogAction("Maintenance: I saw everything, I was at the opposite \nside of the platform."));
//
//            list.Add(new CutsceneWaitAction(5000));
//            list.Add(new CutsceneDialogAction("Maintenance:  I kind of feel sorry for the kid. Why? \nWell he really didn't look like he wanted to do it."));
//            list.Add(new CutsceneWaitAction(5000));
//            list.Add(new CutsceneDialogAction("Maintenance:  His hand was shaking and there was tears \nin his eyes, seemed like he was forced to do it."));
//            list.Add(new CutsceneWaitAction(5000));
//            list.Add(new CutsceneDialogAction("Scott: Well, what are you waiting for? \nLet's get to the tunnels at the top of the platform already."));
//            list.Add(new CutsceneWaitAction(3000));
//            list.Add(new CutsceneDialogAction("Logan: Hold on a minute..."));
//            list.Add(new CutsceneWaitAction(3000));
//            list.Add(new CutsceneDialogAction("Scott: I'm going ahead... \nI can't wait for you if you're going to waste time."));
//            list.Add(new CutsceneWaitAction(2000));
             
            list.Add(new CutscenePlayerLockAction(false));
        }
    }
}