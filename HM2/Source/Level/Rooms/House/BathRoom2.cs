using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class BathRoom2 : Room//sencond floor
    {
        public BathRoom2(bool isTutorial = false)
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-marble");
            
            builder.AddBlock("block-toilet", currentPlan.Find("o"), 1, "The toilet.");
            builder.AddBlock("block-tub", currentPlan.Find("t"), 2, "The tub.");
            
            builder.AddWall("wall-beige", 1, 13, 1);

            builder.AddWall("wall-beige", currentPlan.Find("d0"));
            builder.AddBlock("block-shelf", currentPlan.Find("s"), 2, Item.ItemType.BANDAGE, "You found some BANDAGES on the shelf. \nThis can help treat her.", PlayerActor.Orientation.UP);

            if (!isTutorial)
                builder.AddItemTile(Item.ItemType.BUCKET, currentPlan.Find("i1"));

            string m1 = "d2";
            string m2 = "d5";
            Util.Mutate1(ref m1, ref m2);

            var hallway = RoomPlans.Get(typeof(HouseHallwayTwoRoom).Name);
            builder.AddRoomTransition(typeof(HouseHallwayTwoRoom), currentPlan.Find("d0"), hallway.Find(m1).Right);

            builder.FillEdges();
        }
    }
}
