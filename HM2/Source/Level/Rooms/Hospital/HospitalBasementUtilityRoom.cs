using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class HospitalBasementUtilityRoom : Room
    {
        RoomBuilder builder;
        public HospitalBasementHallway bHall;
        
        public HospitalBasementUtilityRoom()
        {

            builder = new RoomBuilder(this);

            //Floor
            builder.FillFloor("floor-hospital");
            //Walls
            builder.AddWall("wall-hospital", 1, 8, 1);

            //Transitions/Objects

            builder.AddBlock("regWire", currentPlan.Find("w0"), 1, cutWire, "Rip the wire", "Leave");

            var hallway = RoomPlans.Get(typeof(HospitalBasementHallway).Name);
            builder.AddRoomTransition(typeof(HospitalBasementHallway), currentPlan.Find("d0"), hallway.Find("d1").Bottom);

            builder.FillEdges();

        }

         public override void OnRoomCreation(Level level)
        {
            bHall = level.GetRoom<HospitalBasementHallway>(typeof(HospitalBasementHallway));
        }

        public void cutWire(int i){
            if(i == 1){
            builder.ClearOnStep(currentPlan.Find("w0"));
            builder.AddBlock("cutWire", currentPlan.Find("w0"), 1, "The wire is ripped");
            bHall.toggleLight(4);
            bHall.toggleLight(5);
            }
        }
    }
}
