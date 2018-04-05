using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class ClosetRoom : Room
    {
        public ClosetRoom()
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-wood");


            builder.AddBlock("block-shelf", currentPlan.Find("s"), 1, "Lots of stuff in here.");
            builder.AddBlock("block-shelf", currentPlan.Find("t"), 1, "Lots of stuff in here.");
            builder.AddBlock("block-shelf", currentPlan.Find("u"), 1, "Lots of stuff in here.");
            builder.AddBlock("block-shelf", currentPlan.Find("o"), 1, "Lots of stuff in here.");
            //builder.AddWall("wall-beige", 1, 13, 1);
           // builder.AddWall("wall-beige", currentPlan.Find("d0"));

            var hallway = RoomPlans.Get(typeof(HouseHallwayOneRoom).Name);
            builder.AddRoomTransition(typeof(HouseHallwayOneRoom), currentPlan.Find("d0"), hallway.Find("d10").Right);

            builder.FillEdges();
        }
    }
}

