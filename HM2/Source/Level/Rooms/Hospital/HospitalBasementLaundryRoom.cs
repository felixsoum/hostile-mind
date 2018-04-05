using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class HospitalBasementLaundryRoom : Room
    {
        public HospitalBasementLaundryRoom()
        {

            var builder = new RoomBuilder(this);

            //Floor
            builder.FillFloor("floor-hospital");
            //Walls
            builder.AddWall("wall-hospital", 1, 8, 1);

            //Transitions/Objects

            builder.AddBlock("h-wall-hospital-laundrychute", currentPlan.Find("s1"), 1, "This is the end of the line...");

            var hallway = RoomPlans.Get(typeof(HospitalBasementHallway).Name);
            builder.AddRoomTransition(typeof(HospitalBasementHallway), currentPlan.Find("d0"), hallway.Find("d0").Right);

            builder.FillEdges();

        }
    }
}
