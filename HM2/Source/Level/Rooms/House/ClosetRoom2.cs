using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class ClosetRoom2 : Room
    {
        public ClosetRoom2(bool isTutorial = false)
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-wood");


            builder.AddBlock("block-shelf", currentPlan.Find("s"), 1, "Lots of stuff in here.");
            builder.AddBlock("block-shelf", currentPlan.Find("t"), 1, "Lots of stuff in here.");
            builder.AddBlock("block-shelf", currentPlan.Find("u"), 1, "Lots of stuff in here.");
            builder.AddBlock("block-shelf", currentPlan.Find("o"), 1, "Lots of stuff in here.");

            if (!isTutorial)
                builder.AddItemTile(Item.ItemType.TOWEL, currentPlan.Find("i0"));

            var hallway2 = RoomPlans.Get(typeof(HouseHallwayTwoRoom).Name);
            builder.AddRoomTransition(typeof(HouseHallwayTwoRoom), currentPlan.Find("d0"), hallway2.Find("d0").Left);

            builder.FillEdges();
        }
    }
}

