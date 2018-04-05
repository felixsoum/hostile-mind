using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class HospitalBasementHallway : Room
    {

        RoomBuilder builder;
        LightSource ls1;
        LightSource ls2;
        LightSource ls3;
        LightSource ls4;
        LightSource ls5;
        LightSource ls6;
        LightSource ls7;
        LightSource ls8;
        LightSource ls9;
        LightSource ls10;

        public HospitalBasementHallway()
        {
            builder = new RoomBuilder(this);

            //Floor
            builder.FillFloor("floor-hospital");
            
            //Walls
            builder.AddWall("wall-hospital", 3, 21, 1);
            builder.AddWall("wall-hospital", 26, 30, 1);
            builder.AddWall("wall-hospital", 32, 35, 1);
            builder.AddWall("wall-hospital", 7, 15, 13);
            builder.AddWall("wall-hospital", 3, 11, 25);
            builder.AddWall("wall-hospital", 22, 27, 28);
            builder.AddWall("wall-hospital", 29, 31, 28);
            
            //Transitions/Objects

            //builder.AddBlock("block-chair-brown", currentPlan.Find("c0"), 1, CHAIR_TEXT);

            var laundryRoom = RoomPlans.Get(typeof(HospitalBasementLaundryRoom).Name);
            builder.AddRoomTransition(typeof(HospitalBasementLaundryRoom), currentPlan.Find("d0"), laundryRoom.Find("d0").Left);

            var utilityRoom = RoomPlans.Get(typeof(HospitalBasementUtilityRoom).Name);
            builder.AddRoomTransition(typeof(HospitalBasementUtilityRoom), currentPlan.Find("d1"), utilityRoom.Find("d0").Top);

            var switchRoom = RoomPlans.Get(typeof(HospitalBasementSwitchRoom).Name);
            builder.AddRoomTransition(typeof(HospitalBasementSwitchRoom), currentPlan.Find("d2"), switchRoom.Find("d0").Right);

            var keyRoom1 = RoomPlans.Get(typeof(HospitalBasementKeyRoom1).Name);
            builder.AddRoomTransition(typeof(HospitalBasementKeyRoom1), currentPlan.Find("d3"), keyRoom1.Find("d0").Left);

            var keyRoom2 = RoomPlans.Get(typeof(HospitalBasementKeyRoom2).Name);
            builder.AddRoomTransition(typeof(HospitalBasementKeyRoom2), currentPlan.Find("d4"), keyRoom2.Find("d0").Left);   
            
            var breakerRoom = RoomPlans.Get(typeof(HospitalBasementBreakerRoom).Name);
            builder.AddRoomTransition(typeof(HospitalBasementBreakerRoom), currentPlan.Find("d5"), laundryRoom.Find("d0").Left);

            var elevator = RoomPlans.Get(typeof(HospitalElevator).Name);
            builder.AddRoomTransition(typeof(HospitalElevator), currentPlan.Find("e1"), elevator.Find("d0").Top);

            builder.FillEdges();

            foreach (var x in currentPlan.FindAll("x"))
            {
                var enemy = new EnemyActor();
                enemy.Position = x.ToVector();
                enemy.Ai = new NullAi();
                AddNpc(enemy);
            }
           
            for (int i = 4; i <= 10; i++)
            {
                TurnOnLight(i);
            }
            
            foreach (var c in currentPlan.FindAll("#"))
            {
                builder.ClearFloor(c);
            }
        }

        public void TurnOnLight(int index)
        {
            switch (index)
            {
                case 1:
                    ls1 = builder.AddLightSource(currentPlan.Find("l1"), 5.5f);
                    break;
                case 2:
                    ls2 = builder.AddLightSource(currentPlan.Find("l2"), 5.5f);
                    break;
                case 3:
                    ls3 = builder.AddLightSource(currentPlan.Find("l3"), 5.5f);
                    break;
                case 4:
                    ls4 = builder.AddLightSource(currentPlan.Find("l4"), 5.5f);
                    break;
                case 5:
                    ls5 = builder.AddLightSource(currentPlan.Find("l5"), 5.5f);
                    break;
                case 6:
                    ls6 = builder.AddLightSource(currentPlan.Find("l6"), 6.8f);
                    break;
                case 7:
                    ls7 = builder.AddLightSource(currentPlan.Find("l7"), 6.8f);
                    break;
                case 8:
                    ls8 = builder.AddLightSource(currentPlan.Find("l8"), 6.8f);
                    break;
                case 9:
                    ls9 = builder.AddLightSource(currentPlan.Find("l9"), 6.8f);
                    break;
                case 10:
                    ls10 = builder.AddLightSource(currentPlan.Find("l10"), 6.8f);
                    break;

            }
        }

        public void toggleLight(int index)
        {
            switch(index){
                case 1:
                    ls1.toggleLightSource();
                    break;
                case 2:
                    ls2.toggleLightSource();
                    break;
                case 3:
                    ls3.toggleLightSource();
                    break;
                case 4:
                    ls4.toggleLightSource();
                    break;
                case 5:
                    ls5.toggleLightSource();
                    break;
                case 6:
                    ls6.toggleLightSource();
                    break;
                case 7:
                    ls7.toggleLightSource();
                    break;
                case 8:
                    ls8.toggleLightSource();
                    break;
                case 9:
                    ls9.toggleLightSource();
                    break;
                case 10:
                    ls10.toggleLightSource();
                    break;

            }
        }

    }
}
