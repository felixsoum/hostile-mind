using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class SubwayStreet : Room
    {
        private bool isPlaying = false;
        private SubwayEndingCutscene se;
        public SubwayStreet()
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-concrete-test");
            builder.FillFloor("floor-sidewalk", 1, 1, 24, 3);
            builder.FillFloor( "floor-road-large", 1, 4, 24, 6);
            builder.FillFloor("floor-sidewalk", 1, 10, 24, 3);
            var maintHallway4 = RoomPlans.Get(typeof(SubwayMaintHallway4).Name);
            builder.AddRoomTransition(typeof(SubwayMaintHallway4), currentPlan.Find("d0"), maintHallway4.Find("d3").Right);
            builder.AddRoomTransition(typeof(SubwayMaintHallway4), currentPlan.Find("d1"), maintHallway4.Find("d4").Right);
            builder.AddBlock("block-crate", currentPlan.Find("S"), 1);
            builder.AddBlock("block-crate", currentPlan.Find("B"), 1);

            builder.AddBlock("npc-stm", currentPlan.Find("S"), 1, onChoice, "Speak to Scott.", "Ignore him.");
            //builder.AddBlock("block-crate", currentPlan.Find("S"), 1);
            builder.AddBlock("npc-stm", currentPlan.Find("B"), 1, onChoice, "Speak to the dead body.", "Ignore him.");

            //foreach (var c in currentPlan.FindAll("#"))
            //    builder.ClearFloor(c);

            builder.FillEdges();

            builder.AutomaticWall("wall-tunnel");
            se = new SubwayEndingCutscene();
            

            //CutsceneServant.Set(GameInfo.CurrentLevel, new SubwayEndingCutscene());
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
        public override void Update()
        {
            base.Update();
            if (isPlaying)
                return;
            
            isPlaying = true;
            CutsceneServant.Set(GameInfo.CurrentLevel, se);
            
            
        }
    }
}
