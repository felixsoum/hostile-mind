using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class SmallBedRoom : Room
    {
        public SmallBedRoom()
            : base(16, 11)
        {
            var builder = new RoomBuilder(this);
            builder.FillFloor("floor-carpet");
            
            builder.AddItemTile(Item.ItemType.PILL, 10, 1);
            builder.AddWall("wall-beige", 1, 14, 1);

            builder.AddBlock("block-bed-test", new RoomIndex(6, 2), 2, "The bed in the guest bedroom is empty.");

            builder.AddRoomTransition(typeof(HouseHallwayOneRoom), 15, 5, 9, 33);
            builder.FillEdges();
        }
    }
}

