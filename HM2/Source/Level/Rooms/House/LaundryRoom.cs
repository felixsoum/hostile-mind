using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class LaundryRoom : Room
    {
        public LaundryRoom(bool isTutorial = false)
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-wood");

            builder.AddWall("wall-beige", 1, 13, 1);

            if (!isTutorial)
                builder.AddBlock("block-dryer", currentPlan.Find("d"), 2, Item.ItemType.TOWEL, "You found some TOWELS in the dryer.\nThis may help stop the bleeding.", PlayerActor.Orientation.UP);
            else
                builder.AddBlock("block-dryer", currentPlan.Find("d"), 2, Item.ItemType.BLUE_KEY, "You found your car keys in the dryer...", PlayerActor.Orientation.UP);

            builder.AddBlock("block-garbage", currentPlan.Find("g"), 1, Item.ItemType.SMELLINGSALT, "You found thrown out SMELLINGSALT in the garbage.\nThis could easily wake someone up.", PlayerActor.Orientation.DOWN);
            
            builder.AddBlock("block-washer", currentPlan.Find("w"), 1, "The washer.");
            builder.AddBlock("block-table2", currentPlan.Find("t"), 2, "The table.");
            
            var hallway2 = RoomPlans.Get(typeof(HouseHallwayTwoRoom).Name);
            builder.AddRoomTransition(typeof(HouseHallwayTwoRoom), currentPlan.Find("d0"), hallway2.Find("d4").Left);
            builder.AddWall("wall-beige", currentPlan.Find("d0"));

            builder.FillEdges();
        }
    }
}

