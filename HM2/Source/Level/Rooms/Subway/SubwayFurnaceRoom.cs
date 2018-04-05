using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class SubwayFurnaceRoom : Room
    {
        public SubwayFurnaceRoom()
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-concrete-test");

            builder.AddItemTile(Item.ItemType.RED_KEY, currentPlan.Find("rk"));

            var maintHallway2 = RoomPlans.Get(typeof(SubwayMaintHallway2).Name);
            builder.AddRoomTransition(typeof(SubwayMaintHallway2), currentPlan.Find("d0"), maintHallway2.Find("d4").Right);
                       
            builder.FillEdges();

            builder.AutomaticWall("wall-tunnel");
        }
    }
}
