using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class StorageRoom : Room
    {
        private const string BOX_TEXT = "This box is locked.";

        public StorageRoom()
        {
            IsCloneable = true;
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-wood");
            builder.AddWall("wall-beige", 1, 10, 1);

            foreach (var p in currentPlan.FindAll("p"))
                builder.AddPushableBlock("stone-sphere", p);

            foreach (var b in currentPlan.FindAll("b"))
                builder.AddBlock("block-box-small", b, 1, BOX_TEXT);

            builder.AddItemTile(Item.ItemType.AXE, currentPlan.Find("i0"));

            string m1 = "d9";
            string m2 = "d11";
            Util.Mutate2(ref m1, ref m2);

            var hallway = RoomPlans.Get(typeof(HouseHallwayOneRoom).Name);
            builder.AddWall("wall-beige",currentPlan.Find("d0"));
            builder.AddRoomTransition(typeof(HouseHallwayOneRoom), currentPlan.Find("d0"), hallway.Find(m1).Right);
            builder.FillEdges();
        }

        public override Room Clone()
        {
            return new StorageRoom();
        }
    }
}

