using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class SubwaySecretRoom : Room
    {
        RoomBuilder builder;
        private SubwayMaintHallway4 sm4;
        public SubwaySecretRoom()
        {
            

            builder = new RoomBuilder(this);

            builder.FillFloor("floor-concrete-test");

            var maintHallway4 = RoomPlans.Get(typeof(SubwayMaintHallway4).Name);
            builder.AddRoomTransition(typeof(SubwayMaintHallway4), currentPlan.Find("d1"), maintHallway4.Find("d2").Left);

            var maintroom4 = RoomPlans.Get(typeof(SubwayMaintRoom4).Name);
            builder.AddRoomTransition(typeof(SubwayMaintRoom4), currentPlan.Find("d0"), maintroom4.Find("d1").Bottom);

            builder.AddBlock("wall-tunnel-switch-on", currentPlan.Find("w1"), 3, OnSwitchChoice, "Turn Lights off in next room.", "Look for light switch handle.");
            
            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

            foreach (var c in currentPlan.FindAll("w"))
                builder.AddWall("wall-tunnel", c);

            //builder.AddWall("wall-tunnel-switch-on", currentPlan.Find("w1"));
            builder.FillEdges();

            //builder.AutomaticWall("wall-tunnel");
        }
        public void OnSwitchChoice(int x)
        {
            if (x == 1)
            {
                int itemsMissing = 1;

                if (PlayerItems.Has(Item.ItemType.SWITCH))
                    itemsMissing--;

                
                if (itemsMissing == 0)
                {
                    sm4.setLightsOff();
                    builder.AddBlock("wall-tunnel-switch", currentPlan.Find("w1"), 1, "The lights in the next room are now off.");
                }
                else
                {
                    Dialog.SetText("Logan: I'm still missing the light switch handle.");
                }
            }
            else
            {
                Dialog.SetText("Logan: I need to find the light switch...");
            }
        }

        public override void OnRoomCreation(Level level)
        {
            sm4 = level.GetRoom<SubwayMaintHallway4>(typeof(SubwayMaintHallway4));
        }

        

    }
}
