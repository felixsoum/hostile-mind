using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class HospitalMainCurtainRoom3 : Room
    {
        public HospitalMainCurtainRoom3()
        {

            var builder = new RoomBuilder(this);

            //Floor
            builder.FillFloor("floor-hospital");
            //Walls
            builder.AddWall("wall-hospital", 1, 4, 1);

            //Transitions/Objects

            //builder.AddBlock("block-chair-brown", currentPlan.Find("c0"), 1, CHAIR_TEXT);

            var hallway = RoomPlans.Get(typeof(HospitalMainHallway).Name);
            builder.AddRoomTransition(typeof(HospitalMainHallway), currentPlan.Find("d0"), hallway.Find("d6").Top);

            builder.FillEdges();

        }
    }
}
