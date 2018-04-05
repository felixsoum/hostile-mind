using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class GuestRoom : Room
    {
        public GuestRoom()
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-linen");

            builder.AddBlock("block-table2", currentPlan.Find("t"), 2, "This is a table.");
            builder.AddBlock("block-bed-test", currentPlan.Find("b"), 2, "The bed.");
            builder.AddBlock("block-cabinet", currentPlan.Find("c"), 1, "The cabinet.");

            builder.AddWall("wall-beige", 1, 13, 1);
            builder.AddWall("wall-beige", currentPlan.Find("d0"));

            var hallway = RoomPlans.Get(typeof(HouseHallwayOneRoom).Name);
            builder.AddRoomTransition(typeof(HouseHallwayOneRoom), currentPlan.Find("d0"), hallway.Find("d8").Right);
           
            builder.FillEdges();
        }
    }
}

