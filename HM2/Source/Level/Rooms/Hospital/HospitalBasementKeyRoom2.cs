using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class HospitalBasementKeyRoom2 : Room
    {
        public HospitalBasementKeyRoom2()
        {

            var builder = new RoomBuilder(this);

            //Floor
            builder.FillFloor("floor-hospital");
            //Walls
            builder.AddWall("wall-hospital", 1, 8, 1);

            //Transitions/Objects

            //builder.AddBlock("block-chair-brown", currentPlan.Find("c0"), 1, CHAIR_TEXT);

            builder.AddItemTile(Item.ItemType.BLUE_KEY, currentPlan.Find("i0"));

            var hallway = RoomPlans.Get(typeof(HospitalBasementHallway).Name);
            builder.AddRoomTransition(typeof(HospitalBasementHallway), currentPlan.Find("d0"), hallway.Find("d4").Right);

            builder.FillEdges();

        }
    }
}
