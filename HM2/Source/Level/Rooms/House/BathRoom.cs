using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class BathRoom : Room
    {
        public BathRoom()
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-marble");
            
            builder.AddBlock("block-toilet", currentPlan.Find("o"), 1, "The toilet.");
            builder.AddBlock("block-tub", currentPlan.Find("t"), 2, "The tub.");
            builder.AddBlock("block-garbage", currentPlan.Find("t1"), 1, "Nothing useful in here.");
            builder.AddBlock("block-shelf", currentPlan.Find("s"), 1, Item.ItemType.MEDKIT, "You found a MEDKIT on the shelf.\nThis should help treat her.", PlayerActor.Orientation.UP);

            builder.AddWall("wall-beige", 1, 13, 1);

            builder.AddWall("wall-beige", currentPlan.Find("d0"));
            var hallway = RoomPlans.Get(typeof(HouseHallwayOneRoom).Name);
            
            builder.AddRoomTransition(typeof(HouseHallwayOneRoom), currentPlan.Find("d0"), hallway.Find("d7").Right);

            builder.FillEdges();
        }
    }
}
