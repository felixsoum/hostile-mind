using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class Hospital5thFloorDoctorRoom : Room
    {
        public Hospital5thFloorDoctorRoom()
        {

            var builder = new RoomBuilder(this);

            //Floor
            builder.FillFloor("floor-hospital");
            //Walls
            builder.AddWall("wall-hospital", 1, 3, 1);
            builder.AddWall("wall-hospital", 5, 8, 1);

            //Transitions/Objects

            //builder.AddBlock("block-chair-brown", currentPlan.Find("c0"), 1, CHAIR_TEXT);

            var hallway = RoomPlans.Get(typeof(Hospital5thFloorHallway).Name);
            builder.AddRoomTransition(typeof(Hospital5thFloorHallway), currentPlan.Find("d0"), hallway.Find("d9").Top);

            builder.FillEdges();

        }
    }
}
