using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class HospitalBasementBreakerRoom : Room
    {
        
        RoomBuilder builder;
        private HospitalElevator elevator;

        public HospitalBasementBreakerRoom()
        {
            builder = new RoomBuilder(this);
            

            //Floor
            builder.FillFloor("floor-hospital");
            //Walls
            builder.AddWall("wall-hospital", 1, 6, 1);
            builder.AddBlock("h-wall-hospital-breaker-off", currentPlan.Find("b1"), 1, breakerChoice, "Turn On Breaker", "Leave");
            
            //Transitions/Objects

            //builder.AddBlock("block-chair-brown", currentPlan.Find("c0"), 1, CHAIR_TEXT);

            var hallway = RoomPlans.Get(typeof(HospitalBasementHallway).Name);
            builder.AddRoomTransition(typeof(HospitalBasementHallway), currentPlan.Find("d0"), hallway.Find("d5").Right);

            builder.FillEdges();

        }

        public override void OnRoomCreation(Level level)
        {
            elevator = level.GetRoom<HospitalElevator>(typeof(HospitalElevator));
        }

        public void breakerChoice(int x) 
        {
            switch (x)
            {
                case 1:
                    builder.AddBlock("h-wall-hospital-breaker-on", currentPlan.Find("b1"),1,"It's on");
                    Dialog.SetText("**You feel a rumble in the distance**");
                    elevator.setWorking(true);
                    break;
                default:
                    break;
            }
        }
    }
}
