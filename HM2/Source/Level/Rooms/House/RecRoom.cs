using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class RecRoom : Room
    {
        public RecRoom(bool isTutorial = false)
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-linen");
        
            builder.AddBlock("block-pooltable", currentPlan.Find("p"), 3, "How about a quick game?");
            builder.AddBlock("block-tv-back", currentPlan.Find("t"), 1, "Another Rob Ford video released...");
            builder.AddBlock("block-sofa", currentPlan.Find("s"), 1, "The sofa.");
            builder.AddBlock("block-counter", currentPlan.Find("c"), 7, "Hmm, needs a dusting.");
            builder.AddBlock("block-fireplace", currentPlan.Find("f"), 1, "The fireplace.");

            if (!isTutorial)
            {
                builder.AddItemTile(Item.ItemType.ALCOHOL, currentPlan.Find("i0"));
                //builder.AddItemTile(Item.ItemType.KEY, currentPlan.Find("i1"));
            }
            builder.AddWall("wall-beige", 1, 8, 1);
            builder.AddWall("wall-beige", currentPlan.Find("d0"));

            string m1 = "d5";
            string m2 = "d2";
            Util.Mutate1(ref m1, ref m2);

            var hallway2 = RoomPlans.Get(typeof(HouseHallwayTwoRoom).Name);
            builder.AddRoomTransition(typeof(HouseHallwayTwoRoom), currentPlan.Find("d0"), hallway2.Find(m1).Right);

            builder.FillEdges();
        }
    }
}

