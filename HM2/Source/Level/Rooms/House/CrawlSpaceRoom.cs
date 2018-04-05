using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class CrawlSpaceRoom : Room
    {
        private RoomBuilder builder;
        public CrawlSpaceRoom()
        {
            builder = new RoomBuilder(this);

            builder.FillFloor("floor-wood");
            for (int i = 0; i < 12; ++i)
            {
                builder.AddWall("wall-beige" ,i+1, 1);
            }
            builder.AddItemTile(Item.ItemType.PURPLE_KEY, currentPlan.Find("i0"));
            var hallway2 = RoomPlans.Get(typeof(HouseHallwayTwoRoom).Name);
            builder.AddRoomTransition(typeof(HouseHallwayTwoRoom), currentPlan.Find("d0"), hallway2.Find("cs").Bottom);

            builder.FillEdges();
        }
    }
}
