using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class Hospital5thFloorHallway : Room
    {
        
         public Hospital5thFloorHallway()
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

             foreach (var w in currentPlan.FindAll("f3"))
            {
                builder.FillFloor("h-floor-hospital-bprint3", w);
            }

            //Walls
            builder.AddWall("wall-hospital", 1, 30, 1);
            builder.AddWall("wall-hospital", 31, 35, 1);
            builder.AddWall("wall-hospital", 1, 1, 24);
            builder.AddWall("wall-hospital", 3, 6, 24);
            builder.AddWall("wall-hospital", 8, 11, 24);
            builder.AddWall("wall-hospital", 13, 16, 24);
            builder.AddWall("wall-hospital", 18, 21, 24);
            builder.AddWall("wall-hospital", 23, 28, 24);
            builder.AddWall("wall-hospital", 24, 27, 13);
            //Transitions/Objects

             foreach (var w in currentPlan.FindAll("w1"))
            {
            builder.AddWall("h-wall-hospital-redprints1", w);
             }

              foreach (var w in currentPlan.FindAll("w2"))
            {
            builder.AddWall("h-wall-hospital-redprints2", w);
             }

              foreach (var w in currentPlan.FindAll("w3"))
            {
            builder.AddWall("h-wall-hospital-redprints3", w);
             }


            //builder.AddBlock("block-chair-brown", currentPlan.Find("c0"), 1, CHAIR_TEXT);

            var loganStart = RoomPlans.Get(typeof(HospitalLoganStart).Name);
            builder.AddRoomTransition(typeof(HospitalLoganStart), currentPlan.Find("d0"), loganStart.Find("d0").Top);

            var explore1 = RoomPlans.Get(typeof(Hospital5thFloorExplore1).Name);
            builder.AddRoomTransition(typeof(Hospital5thFloorExplore1), currentPlan.Find("d1"), explore1.Find("d0").Top);

            var explore2 = RoomPlans.Get(typeof(Hospital5thFloorExplore2).Name);
            builder.AddRoomTransition(typeof(Hospital5thFloorExplore2), currentPlan.Find("d2"), explore2.Find("d0").Top);

            var fourthBottom = RoomPlans.Get(typeof(Hospital5thFloorExplore3).Name);
            builder.AddRoomTransition(typeof(Hospital5thFloorExplore3), currentPlan.Find("d3"), fourthBottom.Find("d0").Top);

            var fifthBottom = RoomPlans.Get(typeof(Hospital5thFloorExplore4).Name);
            builder.AddRoomTransition(typeof(Hospital5thFloorExplore4), currentPlan.Find("d4"), fifthBottom.Find("d0").Top);

            var elevator = RoomPlans.Get(typeof(HospitalElevator).Name);
            builder.AddRoomTransition(typeof(HospitalElevator), currentPlan.Find("e1"), elevator.Find("d0").Top);

            var utilityRoom = RoomPlans.Get(typeof(Hospital5thFloorUtilityRoom).Name);
            builder.AddRoomTransition(typeof(Hospital5thFloorUtilityRoom), currentPlan.Find("d5"), utilityRoom.Find("d0").Bottom);
            builder.AddItemLockedDoor(currentPlan.Find("d5"), DoorSprite.Orientation.UP, Item.ItemType.PURPLE_KEY, "Hmm... it's locked - maybe there is a key around...");

            var doctorRoom = RoomPlans.Get(typeof(Hospital5thFloorDoctorRoom).Name);
            builder.AddRoomTransition(typeof(Hospital5thFloorDoctorRoom), currentPlan.Find("d9"), doctorRoom.Find("d0").Bottom);
            builder.AddItemLockedDoor(currentPlan.Find("d9"), DoorSprite.Orientation.UP, Item.ItemType.RED_KEY, "Hmm... it's locked \n weird.. the lock is red...");

            var keyRoom1 = RoomPlans.Get(typeof(Hospital5thFloorKeyRoom1).Name);
            builder.AddRoomTransition(typeof(Hospital5thFloorKeyRoom1), currentPlan.Find("d6"), keyRoom1.Find("d0").Bottom);

            var keyRoom2 = RoomPlans.Get(typeof(Hospital5thFloorKeyRoom2).Name);
            builder.AddRoomTransition(typeof(Hospital5thFloorKeyRoom2), currentPlan.Find("d7"), keyRoom2.Find("d0").Bottom);
            builder.AddItemLockedDoor(currentPlan.Find("d7"), DoorSprite.Orientation.UP, Item.ItemType.GREEN_KEY, "Hmm... it's locked \n weird.. the lock is green...");

            var keyRoom3 = RoomPlans.Get(typeof(Hospital5thFloorKeyRoom3).Name);
            builder.AddRoomTransition(typeof(Hospital5thFloorKeyRoom3), currentPlan.Find("d8"), keyRoom2.Find("d0").Bottom);
            builder.AddItemLockedDoor(currentPlan.Find("d8"), DoorSprite.Orientation.UP, Item.ItemType.BLUE_KEY, "Hmm... it's locked \n weird.. the lock is blue...");

            builder.FillEdges();

        foreach (var c in currentPlan.FindAll("#")){
        builder.ClearFloor(c);
		}


        foreach (var x in currentPlan.FindAll("x"))
        {
            var enemy = new EnemyActor();
            enemy.Position = x.ToVector();
            enemy.Ai = new NullAi();
            AddNpc(enemy);
        }


        builder.AddLightSource(currentPlan.Find("l1"), 5.5f);
        builder.AddBlock("block-sofa", currentPlan.Find("s1"), 1, "This is no time to sit");
        builder.AddBlock("block-sofa", currentPlan.Find("s2"), 1, "This is no time to sit");
        builder.AddBlock("block-sofa", currentPlan.Find("s3"), 1, "This is no time to sit");

    }
    }
}
