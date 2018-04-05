using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    class SubwayPlatformLG : Room
    {
        RoomBuilder builder;
        //private bool proceed = false;
        private bool refreshChoice = false;
        //private bool refreshChoice2 = false;
        public SubwayPlatformLG()
        {
			builder = new RoomBuilder(this);

			builder.FillFloor("floor-platform-LG");
            foreach (var c in currentPlan.FindAll("%"))
                builder.FillFloor("floor-edge-LG", c);
            foreach (var c in currentPlan.FindAll("$"))
                builder.FillFloor("floor-edge-2-LG", c);

            builder.AddWall("wall-tunnel",currentPlan.Find("s1"));
            
            
            builder.FillFloor("floor-hstairs", currentPlan.Find("s1"));
            builder.FillFloor("floor-hstairs", currentPlan.Find("s2"));

            var tunnel = RoomPlans.Get(typeof(SubwayTunnelLG).Name);
            builder.AddRoomTransition(typeof(SubwayTunnelLG), currentPlan.Find("s1"), tunnel.Find("s1").Right);
            //builder.AddRoomTransition(typeof(SubwayTunnelLG), currentPlan.Find("s2"), tunnel.Find("s2").Right);
            

            //add tunnel block
            foreach (var c in currentPlan.FindAll("C"))
                builder.AddBlock("floor-concrete-test1", c, 1, "The subway tunnel.");

            builder.AddBlock("npc-stm", currentPlan.Find("S"), 1, onChoice, "Speak to Scott.", "Ignore him.");
            //builder.AddBlock("block-crate", currentPlan.Find("S"), 1);
            builder.AddBlock("npc-stm", currentPlan.Find("B"), 1, onChoice, "Speak to the dead body.", "Ignore him.");
            builder.AddBlock("npc-stm", currentPlan.Find("M"), 1, onChoice, "Speak to the maintenance man.", "Ignore him.");
            builder.AddBlock("npc-stm", currentPlan.Find("J"), 1, onChoice, "Speak to the janitor.", "Ignore him.");
            //builder.AddBlock("block-crate", currentPlan.Find("B"), 1);
            //builder.AddBlock("block-crate", currentPlan.Find("M"), 1);
            //builder.AddBlock("block-crate", currentPlan.Find("J"), 1);

            builder.AddWall("wall-tunnel",1,20,1);
            
            

            var puzzle = RoomPlans.Get(typeof(SubwayPuzzleRoom).Name);
            builder.AddRoomTransition(typeof(SubwayPuzzleRoom), currentPlan.Find("d0"), puzzle.Find("d0").Right);
            builder.AddChoice(onStepChoice, "Are you sure you want to proceed?", "Look around some more.", currentPlan.Find("s1").Left);
            //builder.AddChoice(onStepChoice2, "Are you sure you want to proceed?", "Look around some more.", currentPlan.Find("s2").Left);

            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);
            builder.ClearFloor(currentPlan.Find("s2"));
			builder.FillEdges();
		}
        public void onStepChoice(int x)
        {
            refreshChoice = true;
            //refreshChoice2 = true;  
            if (x == 1)
            {
                //proceed = true;
                Dialog.SetText("Let's go after him.");

                PlayerActor.Instance.AddCommand(new WaitActorCommand(100));
                PlayerActor.Instance.AddCommand(new MoveActorCommand(new Vector2(GameInfo.TILE_X, currentPlan.Find("s1").J*GameInfo.TILE_Y - PlayerActor.Instance.Position.Y)));
                
            }
            else
            {
                Dialog.SetText("I'll Keep looking around, maybe they left some clues.");
                PlayerActor.Instance.AddCommand(new MoveActorCommand(new Vector2(-GameInfo.TILE_X*2, 0)));
                
            }
            
        }
        public void onChoice(int x)
        {
            if (x == 1)
            {

                Dialog.SetText("Hello...");
            }
            else
                Dialog.SetText("I really don't want to talk to him, \nbut I have to find out what's going on...");
            return;
        }
        //public void onStepChoice2(int x)
        //{
        //    //refreshChoice = true;
        //    refreshChoice2 = true;
        //    if (x == 1)
        //    {
        //        //proceed = true;
        //        Dialog.SetText("Let's go after him.");

        //        PlayerActor.Instance.AddCommand(new MoveActorCommand(new Vector2(GameInfo.TILE_X, -GameInfo.TILE_Y)));
        //    }
        //    else
        //    {
        //        Dialog.SetText("I'll Keep looking around, maybe they left some clues.");
        //        PlayerActor.Instance.AddCommand(new MoveActorCommand(new Vector2(-GameInfo.TILE_X*2, 0)));
                
        //    }
        //}
        public override void Update()
        {
            if (refreshChoice && PlayerActor.Instance.Commands.Count == 0)
            {
                refreshChoice = false;
                builder.AddChoice(onStepChoice, "Are you sure you want to proceed?", "Look around some more.", currentPlan.Find("s1").Left);
                //builder.AddChoice(onStepChoice2, "Are you sure you want to proceed?", "Look around some more.", currentPlan.Find("s2").Left);
            }
            /*
            if (proceed == false)
            {
                builder.AddChoice(onStepChoice, "Are you sure you want to proceed?", "Look around some more.", currentPlan.Find("s1").Left);

            }
            else
            {
                builder.ClearOnStep(currentPlan.Find("s1").Left);

            }
             */
            base.Update();
        }
	}
}