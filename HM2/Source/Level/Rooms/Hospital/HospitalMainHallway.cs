using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class HospitalMainHallway : Room
    {

        public HospitalMainHallway()
        {
            var builder = new RoomBuilder(this);

            //Floor
            builder.FillFloor("floor-hospital");
            //Walls
            builder.AddWall("wall-hospital", 5, 14, 1);
            builder.AddWall("wall-hospital", 15, 16, 14);
            builder.AddWall("wall-hospital", 18, 23, 14);
            builder.AddWall("wall-hospital", 25, 25, 14);
            builder.AddWall("wall-hospital", 26, 26, 1);
            builder.AddWall("wall-hospital", 28, 35, 1);
            builder.AddWall("wall-hospital", 29, 35, 9);
            //Transitions/Objects

            //builder.AddBlock("block-chair-brown", currentPlan.Find("c0"), 1, CHAIR_TEXT);

            foreach (var s in currentPlan.FindAll("s"))
            {
                builder.AddBlock("block-sofa", s, 1, "This is no time to sit");
            }

            var staffRoom = RoomPlans.Get(typeof(HospitalMainStaffRoom).Name);
            builder.AddRoomTransition(typeof(HospitalMainStaffRoom), currentPlan.Find("d0"), staffRoom.Find("d0").Top);

            var utilityRoom = RoomPlans.Get(typeof(HospitalMainUtilityRoom).Name);
            builder.AddRoomTransition(typeof(HospitalMainUtilityRoom), currentPlan.Find("d1"), utilityRoom.Find("d0").Bottom);

            var washRoom = RoomPlans.Get(typeof(HospitalMainWashRoom).Name);
            builder.AddRoomTransition(typeof(HospitalMainWashRoom), currentPlan.Find("d2"), washRoom.Find("d0").Top);

            var spareRoom = RoomPlans.Get(typeof(HospitalMainSpareRoom).Name);
            builder.AddRoomTransition(typeof(HospitalMainSpareRoom), currentPlan.Find("d3"), spareRoom.Find("d0").Bottom);

            var curtainRoom1 = RoomPlans.Get(typeof(HospitalMainCurtainRoom1).Name);
            builder.AddRoomTransition(typeof(HospitalMainCurtainRoom1), currentPlan.Find("d4"), curtainRoom1.Find("d0").Bottom);

            var curtainRoom2 = RoomPlans.Get(typeof(HospitalMainCurtainRoom2).Name);
            builder.AddRoomTransition(typeof(HospitalMainCurtainRoom2), currentPlan.Find("d5"), curtainRoom2.Find("d0").Bottom);

            var curtainRoom3 = RoomPlans.Get(typeof(HospitalMainCurtainRoom3).Name);
            builder.AddRoomTransition(typeof(HospitalMainCurtainRoom3), currentPlan.Find("d6"), curtainRoom3.Find("d0").Bottom);

            var extRoom = RoomPlans.Get(typeof(HospitalMainExteriorRoom).Name);
            builder.AddRoomTransition(typeof(HospitalMainExteriorRoom), currentPlan.Find("d7"), extRoom.Find("d0").Left);

            var elevator = RoomPlans.Get(typeof(HospitalElevator).Name);
            builder.AddRoomTransition(typeof(HospitalElevator), currentPlan.Find("e1"), elevator.Find("d0").Top);

            builder.FillEdges();

            foreach (var c in currentPlan.FindAll("#"))
            {
                builder.ClearFloor(c);
            }
        }
    }
}
