using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class SubwayMaintRoom3 : Room
    {
        RoomBuilder builder;
        SubwayMaintHallway3 sm3;

        public SubwayMaintRoom3()
        {
            builder = new RoomBuilder(this);

            builder.FillFloor("floor-concrete-test");
            
            builder.AddItemTile(Item.ItemType.SWITCH, currentPlan.Find("sw"));

            var maintHallway3 = RoomPlans.Get(typeof(SubwayMaintHallway3).Name);
            builder.AddRoomTransition(typeof(SubwayMaintHallway3), currentPlan.Find("d0"), maintHallway3.Find("d4").Right);

            builder.AddBlock("wall-tunnel-switch", currentPlan.Find("w1"), 3, OnSwitchChoice, "Turn Lights off in the previous room?", "Turn the Lights on in the previous room?");
            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

            foreach (var c in currentPlan.FindAll("w"))
                builder.AddWall("wall-tunnel", c);
           
            builder.FillEdges();

            //builder.AutomaticWall("wall-tunnel");
        }
        public void OnSwitchChoice(int x)
        {
            if (x == 1)
            {
                Dialog.SetText("The lights in the tunnel are now off.");
                sm3.IsLightingEnabled = true;
            }
            else
            {
                Dialog.SetText("The lights in the tunnel are now back on.");
                sm3.IsLightingEnabled = false;
            }
        }

        public override void OnRoomCreation(Level level)
        {
            sm3 = level.GetRoom<SubwayMaintHallway3>(typeof(SubwayMaintHallway3));
        }
    }
}
