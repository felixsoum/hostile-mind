using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class HouseHallwayTwoRoom : Room
    {
        private RoomBuilder builder;
        private bool playerCanLeave = false;
        private bool isTutorial;

		public HouseHallwayTwoRoom(bool isTutorial = false)
        {
            IsCloneable = true;
            this.isTutorial = isTutorial;
            builder = new RoomBuilder(this);

            builder.FillFloor("floor-wood");

			if (!isTutorial)
			{
				var hallway = RoomPlans.Get(typeof(HouseHallwayOneRoom).Name);
				builder.AddRoomTransition(typeof(HouseHallwayOneRoom), currentPlan.Find("s0"), hallway.Find("s0").Left);
                var crawlSpace = RoomPlans.Get(typeof(CrawlSpaceRoom).Name);
                builder.AddRoomTransition(typeof(CrawlSpaceRoom), currentPlan.Find("cs"), crawlSpace.Find("d0").Top);
			}
			else
			{
                builder.AddDialogToTile("Wait... I need to find my car keys before leaving", currentPlan.Find("s0"));
                builder.AddCommandToTile(PlayerActor.Instance, new MoveActorCommand(new Vector2(GameInfo.TILE_X, 0)), currentPlan.Find("s0"));
                builder.ClearFloor(currentPlan.Find("cs"));
            }

            var closet2 = RoomPlans.Get(typeof(ClosetRoom2).Name);
            builder.AddRoomTransition(typeof(ClosetRoom2), currentPlan.Find("d0"), closet2.Find("d0").Right);

            var masterBedroom = RoomPlans.Get(typeof(MasterBedRoom).Name);
            builder.AddRoomTransition(typeof(MasterBedRoom), currentPlan.Find("d1"), masterBedroom.Find("d0").Right);


            string m1 = "d2";
            string m2 = "d5";

            Util.Mutate1(ref m1, ref m2);

            var bathroom = RoomPlans.Get(typeof(BathRoom2).Name);
            builder.AddRoomTransition(typeof(BathRoom2), currentPlan.Find(m1), bathroom.Find("d0").Left);

            var recRoom = RoomPlans.Get(typeof(RecRoom).Name);
            builder.AddRoomTransition(typeof(RecRoom), currentPlan.Find(m2), recRoom.Find("d0").Left);

            var closet3 = RoomPlans.Get(typeof(ClosetRoom3).Name);
            builder.AddRoomTransition(typeof(ClosetRoom3), currentPlan.Find("d3"), closet3.Find("d0").Left);
            builder.AddItemLockedDoor(currentPlan.Find("d3"), DoorSprite.Orientation.RIGHT, Item.ItemType.PURPLE_KEY,
                "Logan: Did I hear something in there? \nBut the door is locked, where did I put the key?");

            var laundry = RoomPlans.Get(typeof(LaundryRoom).Name);
            builder.AddRoomTransition(typeof(LaundryRoom), currentPlan.Find("d4"), laundry.Find("d0").Right);


           
            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

            builder.AutomaticWall("wall-beige");

            if (!isTutorial)
            {
                builder.AddPushableBlock("block-shelf", currentPlan.Find("c"));
                builder.ClearWall(currentPlan.Find("cs"));
                builder.AddWall("wall-beige-hole", currentPlan.Find("c"));
            }
            else
            {
                foreach (var l in currentPlan.FindAll("ls"))
                    builder.AddLightSource(l, 6.5f, 0.5f);
            }
        }

        public override void Update()
        {
            base.Update();
            if (!isTutorial)
                return;

            if (!playerCanLeave && PlayerItems.Has(Item.ItemType.BLUE_KEY))
            {
                playerCanLeave = true;
                builder.ClearOnStep(currentPlan.Find("s0"));
                builder.AddStateTransition(new CarCinematic(), currentPlan.Find("s0"));
            }
        }

        public void FixShelf()
        {
            builder.AddBlock("block-shelf", currentPlan.Find("c"), 1, "Nothing here...");
        }

        public override Room Clone()
        {
            return new HouseHallwayTwoRoom(isTutorial);
        }
    }
}

