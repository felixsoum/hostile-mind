using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class SubwayMaintHallway1 : Room
    {
        public SubwayMaintHallway1()
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-concrete-test");

            foreach (var c in currentPlan.FindAll("d1"))
                builder.FillFloor("floor-hstairs", c);

            foreach (var c in currentPlan.FindAll("b"))
                builder.AddPushableBlock("block-garbage", c);

            foreach (var c in currentPlan.FindAll("c"))
                builder.AddBlock("block-crate", c, 1, "");

           // builder.AddBlock("block-tool-cabinet", currentPlan.Find("tc"), 1);
            builder.AddBlock("block-tool-cabinet", currentPlan.Find("tc"), 1, Item.ItemType.RED_KEY, Item.ItemType.BOLTCUTTERS, "I need a key to open this cabinet.","I can cut the chain with these bolt cutters.");
            foreach (var c in currentPlan.FindAll("d1"))
                builder.FillFloor("floor-hstairs", c);

            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

            var tunnel = RoomPlans.Get(typeof(SubwayTunnelLG).Name);
            builder.AddRoomTransition(typeof(SubwayTunnelLG), currentPlan.Find("d1"), tunnel.Find("d1").Bottom);

            var mainthallway2 = RoomPlans.Get(typeof(SubwayMaintHallway2).Name);
            builder.AddRoomTransition(typeof(SubwayMaintHallway2), currentPlan.Find("d2"), mainthallway2.Find("d0").Top);
            builder.AddRoomTransition(typeof(SubwayMaintHallway2), currentPlan.Find("d3"), mainthallway2.Find("d1").Top);
            

            //builder.FillEdges();
            builder.AutomaticWall("wall-tunnel");
        }
    }
}
