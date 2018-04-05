using System;

namespace HostileMind
{
    public class OutsideRoom : Room
    {
        public OutsideRoom()
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-grass");
            builder.AddWall("wall-fence", 0, 28, 1);
            builder.AddWall("wall-outside", 4, 12, 44);
            builder.AddWall("wall-outside", 14, 22, 44);
            var backDoor = RoomPlans.Get(typeof(HouseHallwayOneRoom).Name);
            builder.AddRoomTransition(typeof(HouseHallwayOneRoom), currentPlan.Find("d0"), backDoor.Find("d12").Bottom);

            var frontDoor = RoomPlans.Get(typeof(HouseHallwayOneRoom).Name);
            builder.AddRoomTransition(typeof(HouseHallwayOneRoom), currentPlan.Find("d1"), frontDoor.Find("d13").Top);

            //var window = RoomPlans.Get(typeof(LockedRoom).Name);
            //builder.AddRoomTransition(typeof(LockedRoom), currentPlan.Find("w"), window.Find("w").Right);

            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);
        }
    }
}

