using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class Hospital5thFloorExplore2 : Room
    {
        public Hospital5thFloorExplore2()
        {

            var builder = new RoomBuilder(this);

            //Floor
            builder.FillFloor("floor-hospital");
            //Walls
            builder.AddWall("wall-hospital", 1, 8, 1);

            //Transitions/Objects

            //builder.AddBlock("block-chair-brown", currentPlan.Find("c0"), 1, CHAIR_TEXT);

            var hallway = RoomPlans.Get(typeof(Hospital5thFloorHallway).Name);
            builder.AddRoomTransition(typeof(Hospital5thFloorHallway), currentPlan.Find("d0"), hallway.Find("d2").Bottom);

            builder.FillEdges();

        }
    }
}
