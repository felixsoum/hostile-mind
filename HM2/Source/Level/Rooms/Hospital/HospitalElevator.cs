using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class HospitalElevator : Room
    {
        int currentFloor = 5;
        bool working = false;
        RoomBuilder builder;

        public HospitalElevator()
        {

            builder = new RoomBuilder(this);

            //Floor
            builder.FillFloor("floor-hospital");
            //Walls
            builder.AddWall("h-elevator-hospital", 1, 1, 1);
            //builder.AddWall("h-elevator-hospital", 3, 4, 1);
           
            builder.AddBlock("h-elevator-hospital-buttons", currentPlan.Find("d1"), 1, "The elevator isn't working... ");
            
            builder.FillEdges();

        }

        public void setWorking(bool w)
        {
            builder.ClearOnStep(currentPlan.Find("d1"));
            builder.AddBlock("h-elevator-hospital-buttonson", currentPlan.Find("d1"), 1, changeFloor, "Basement", "Main Floor", "5th Floor");  
        }

        public void setFloor(int i){
            currentFloor = i;
        }

        public override void OnTransition(Room previousroom)
        {
            switch (previousroom.GetType().Name)
            {
                case "Hospital5thFloorHallway":
                    exitFloor(3);
                    break;
                case "HospitalMainHallway":
                    exitFloor(2);
                    break;
                case "HospitalBasementHallway":
                    exitFloor(1);
                    break;
            }
        }

        public void exitFloor(int i)
        {
             builder.ClearOnStep(currentPlan.Find("d0"));

                switch (i)
                {
                    case 1:
                        var basement = RoomPlans.Get(typeof(HospitalBasementHallway).Name);
                        builder.AddRoomTransition(typeof(HospitalBasementHallway), currentPlan.Find("d0"), basement.Find("e1").Bottom);
                        break;
                    case 2:
                        var main = RoomPlans.Get(typeof(HospitalMainHallway).Name);
                        builder.AddRoomTransition(typeof(HospitalMainHallway), currentPlan.Find("d0"), main.Find("e1").Bottom);
                        break;
                    case 3:
                        var fifth = RoomPlans.Get(typeof(Hospital5thFloorHallway).Name);
                        builder.AddRoomTransition(typeof(Hospital5thFloorHallway), currentPlan.Find("d0"), fifth.Find("e1").Bottom);
                        break;

                }


        }

        public void changeFloor(int i)
        {
                switch (i)
                {
                    case 1:
                        Dialog.SetText("You push the basement button \n ...and are now at that floor");
                        var basement = RoomPlans.Get(typeof(HospitalBasementHallway).Name);
                        builder.AddRoomTransition(typeof(HospitalBasementHallway), currentPlan.Find("d0"), basement.Find("e1").Bottom);
                        break;
                    case 2:
                        Dialog.SetText("You push the Main Floor button \n ...and are now at that floor");
                        var main = RoomPlans.Get(typeof(HospitalMainHallway).Name);
                        builder.AddRoomTransition(typeof(HospitalMainHallway), currentPlan.Find("d0"), main.Find("e1").Bottom);
                        break;
                    case 3:
                        Dialog.SetText("You push the 5th floor button \n ...and are now at that floor");
                        var fifth = RoomPlans.Get(typeof(Hospital5thFloorHallway).Name);
                        builder.AddRoomTransition(typeof(Hospital5thFloorHallway), currentPlan.Find("d0"), fifth.Find("e1").Bottom);
                        break;
                } 

        }

    }
}
