using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class SubwayMaintRoom2 : Room
    {
        RoomBuilder builder;
        SubwayMaintHallway2 sm2;

        public SubwayMaintRoom2()
        {
            builder = new RoomBuilder(this);

            builder.FillFloor("floor-concrete-test");
           
            builder.AddItemTile(Item.ItemType.KEYCARD, currentPlan.Find("kc"));
            var maintHallway2 = RoomPlans.Get(typeof(SubwayMaintHallway2).Name);
            builder.AddRoomTransition(typeof(SubwayMaintHallway2), currentPlan.Find("d0"), maintHallway2.Find("d6").Left);
            builder.AddWall("wall-tunnel", currentPlan.Find("d0"));

            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

            

            builder.AddBlock("wall-tunnel-switch", currentPlan.Find("w1"), 3, OnSwitchChoice, "Turn Lights off in the previous room?", "Turn the Lights on in the previous room?");

            builder.FillEdges();
            foreach (var c in currentPlan.FindAll("w"))
                builder.AddWall("wall-tunnel", c);
            //builder.AutomaticWall("wall-tunnel");
        }
        public void OnSwitchChoice(int x)
        {
            if (x == 1)
            {
                Dialog.SetText("The lights in the previous room are now off.");
                sm2.IsLightingEnabled = true;
            }
            else
            {
                Dialog.SetText("The lights in the previous room are now back on.");
                sm2.IsLightingEnabled = false;
            }
        }

        public override void OnRoomCreation(Level level)
        {
            sm2 = level.GetRoom<SubwayMaintHallway2>(typeof(SubwayMaintHallway2));
        }
    }
}
