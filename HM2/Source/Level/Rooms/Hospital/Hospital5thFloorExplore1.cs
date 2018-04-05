using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class Hospital5thFloorExplore1 : Room
    {
         public Hospital5thFloorExplore1()
        {
        
             var builder = new RoomBuilder(this);

            //Floor
            builder.FillFloor("floor-hospital");
            
            foreach (var w in currentPlan.FindAll("f1"))
            {
                builder.FillFloor("h-floor-hospital-bprint1", w);
            }

            foreach (var w in currentPlan.FindAll("f2"))
            {
                builder.FillFloor("h-floor-hospital-bprint2", w);
            }
             
             
             //Walls
            builder.AddWall("wall-hospital", 1, 8, 1);
           
            //Transitions/Objects

            //builder.AddBlock("block-chair-brown", currentPlan.Find("c0"), 1, CHAIR_TEXT);

            Dialog.SetText("Weird.. what is going on here????", 7000);

            var hallway = RoomPlans.Get(typeof(Hospital5thFloorHallway).Name);
            builder.AddRoomTransition(typeof(Hospital5thFloorHallway), currentPlan.Find("d0"), hallway.Find("d1").Bottom);

            builder.FillEdges();

    }
    }
}
