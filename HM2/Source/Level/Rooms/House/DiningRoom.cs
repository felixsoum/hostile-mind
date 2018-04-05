using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class DiningRoom : Room
    {
        private const string CHAIR_TEXT = "An empty wooden chair.";

        public DiningRoom()
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-marble");

            builder.AddBlock("block-table", currentPlan.Find("t"), 5, "The table in the dining room wasn't set for dinner.");
            builder.AddBlock("block-chair-brown", currentPlan.Find("c0"), 1, CHAIR_TEXT);
            builder.AddBlock("block-chair-brown", currentPlan.Find("c1"), 1, CHAIR_TEXT, true);
            builder.AddBlock("block-chair-brown", currentPlan.Find("c2"), 1, CHAIR_TEXT);
            builder.AddBlock("block-chair-brown", currentPlan.Find("c3"), 1, CHAIR_TEXT, true);

            

            builder.AddWall("wall-beige", 1, 8, 1);

            var hallway = RoomPlans.Get(typeof(HouseHallwayOneRoom).Name);
            builder.AddRoomTransition(typeof(HouseHallwayOneRoom), currentPlan.Find("d0"), hallway.Find("d0").Bottom);
            builder.AddRoomTransition(typeof(HouseHallwayOneRoom), currentPlan.Find("d1"), hallway.Find("d1").Bottom);

            builder.FillEdges();
        }
    }
}

