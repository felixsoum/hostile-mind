using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
	public class HouseHallwayOneRoom : Room
	{
		public HouseHallwayOneRoom()
		{
            var builder = new RoomBuilder(this);

			builder.FillFloor("floor-wood");
            builder.AddWall("wall-beige", 1, 6, 1);
            builder.AddWall("wall-beige", 8, 23, 1);
            builder.AddWall("wall-beige", 12, 13, 24);
            builder.AddWall("wall-beige", 16, 19, 24);
            builder.AddWall("wall-beige", 22, 23, 24);

            var diningRoom = RoomPlans.Get(typeof(DiningRoom).Name);
            builder.AddRoomTransition(typeof(DiningRoom), currentPlan.Find("d0"), diningRoom.Find("d0").Top);
            builder.AddRoomTransition(typeof(DiningRoom), currentPlan.Find("d1"), diningRoom.Find("d1").Top);

            var hallway2 = RoomPlans.Get(typeof(HouseHallwayTwoRoom).Name);
            builder.AddRoomTransition(typeof(HouseHallwayTwoRoom), currentPlan.Find("s0"), hallway2.Find("s0").Right);
            builder.AddWall("wall-beige", 12, 15);
            
            var closetRoom = RoomPlans.Get(typeof(ClosetRoom).Name);
            builder.AddRoomTransition(typeof(ClosetRoom), currentPlan.Find("d10"), closetRoom.Find("d0").Left);
            
            builder.AddWall("wall-beige", 0, 2);
            var kitchenRoom = RoomPlans.Get(typeof(KitchenRoom).Name);
            builder.AddRoomTransition(typeof(KitchenRoom), currentPlan.Find("d2"), kitchenRoom.Find("d0").Top);
            builder.AddRoomTransition(typeof(KitchenRoom), currentPlan.Find("d3"), kitchenRoom.Find("d1").Top);

            var livingRoom = RoomPlans.Get(typeof(LivingRoom).Name);
            builder.AddRoomTransition(typeof(LivingRoom), currentPlan.Find("d4"), livingRoom.Find("d0").Bottom);
            builder.AddRoomTransition(typeof(LivingRoom), currentPlan.Find("d5"), livingRoom.Find("d1").Bottom);
            builder.AddRoomTransition(typeof(LivingRoom), currentPlan.Find("d6"), livingRoom.Find("d2").Right);
            builder.AddWall("wall-beige", 13, 34);

            builder.AddWall("wall-beige", 6, 18);
            var bathRoom = RoomPlans.Get(typeof(BathRoom).Name);
            builder.AddRoomTransition(typeof(BathRoom), currentPlan.Find("d7"), bathRoom.Find("d0").Left);

            builder.AddWall("wall-beige", 6, 27);
            var guestRoom = RoomPlans.Get(typeof(GuestRoom).Name);
            builder.AddRoomTransition(typeof(GuestRoom), currentPlan.Find("d8"), guestRoom.Find("d0").Left);
            //builder.AddItemLockedDoor(currentPlan.Find("d8"), DoorSprite.Orientation.RIGHT, Item.ItemType.KEY, "Did I hear something in there? \nBut the door is locked, where did I put the key?");

            string m1 = "d9";
            string m2 = "d11";
            Util.Mutate2(ref m1, ref m2);

            builder.AddWall("wall-beige", 8, 38);
            var storageRoom = RoomPlans.Get(typeof(StorageRoom).Name);
            builder.AddRoomTransition(typeof(StorageRoom), currentPlan.Find(m1), storageRoom.Find("d0").Left);
            builder.AddItemLockedDoor(currentPlan.Find(m1), DoorSprite.Orientation.RIGHT, Item.ItemType.KEY,
                                      "This door leads to the storage room,\nbut it is locked at the moment.");

            var lockedRoom = RoomPlans.Get(typeof(LockedRoom).Name);
            builder.AddRoomTransition(typeof(LockedRoom), currentPlan.Find(m2), lockedRoom.Find("d0").Left);
            builder.AddWall("wall-beige", 6, 10);
            builder.AddItemLockedDoor(currentPlan.Find(m2), DoorSprite.Orientation.RIGHT, Item.ItemType.AXE,
                                      "This door seems to be locked from the inside.\nI need some kind of weapon to break it down.");


            var backDoor = RoomPlans.Get(typeof(OutsideRoom).Name);
            builder.AddRoomTransition(typeof(OutsideRoom), currentPlan.Find("d12"), backDoor.Find("d0").Top);

            var frontDoor = RoomPlans.Get(typeof(OutsideRoom).Name);
            builder.AddRoomTransition(typeof(OutsideRoom), currentPlan.Find("d13"), frontDoor.Find("d1").Bottom);

            builder.AddBlock("block-shelf", new RoomIndex(17, 24), 1, "This is a shelf.");

			//builder.AddChoice(EndChoice, "Go to hospital", "Go to subway", currentPlan.Find("x"));

            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);
		}

		public void EndChoice(int x)
		{
			switch (x)
			{
				case 1:
					GameDirector.TransitionTo(new MidComaLevel(new MidComaHospitalCutscene()));
					break;
				default:
					GameDirector.TransitionTo(new MidComaLevel(new MidComaSubwayCutscene()));
					break;
			}
		}
        
        public Vector2 GetPlayerStart()
        {
            return currentPlan.Find("a").ToVector();
        }
	}
}

