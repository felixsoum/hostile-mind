using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class SubwayMaintRoom4 : Room
    {
        public SubwayMaintRoom4()
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-concrete-test");
            builder.AddPushableBlock("block-crate",currentPlan.Find("c"));
            var maintHallway3 = RoomPlans.Get(typeof(SubwayMaintHallway3).Name);
            builder.AddRoomTransition(typeof(SubwayMaintHallway3), currentPlan.Find("d0"), maintHallway3.Find("d5").Left);

            var secretRoom = RoomPlans.Get(typeof(SubwaySecretRoom).Name);
            builder.AddRoomTransition(typeof(SubwaySecretRoom), currentPlan.Find("d1"), secretRoom.Find("d0").Top);

            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

            builder.FillEdges();

            builder.AutomaticWall("wall-tunnel");
        }
    }
}
