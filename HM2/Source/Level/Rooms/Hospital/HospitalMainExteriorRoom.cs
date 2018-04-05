using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class HospitalMainExteriorRoom : Room
    {
        public HospitalMainExteriorRoom()
        {

            var builder = new RoomBuilder(this);

            //Floor
            builder.FillFloor("h-road");
            //Walls
            //builder.AddWall("wall-hospital", 1, 8, 1);

            //Transitions/Objects

            //builder.AddBlock("block-chair-brown", currentPlan.Find("c0"), 1, CHAIR_TEXT);

            builder.AddItemTile(Item.ItemType.RED_KEY, currentPlan.Find("i0"));

            var hallway = RoomPlans.Get(typeof(HospitalMainHallway).Name);
            builder.AddRoomTransition(typeof(HospitalMainHallway), currentPlan.Find("d0"), hallway.Find("d7").Right);

            builder.FillEdges();

        }
    }
}
