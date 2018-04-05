using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class SubwayPuzzleRoom : Room
    {
        public SubwayPuzzleRoom()
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-concrete-test");

            foreach (var c in currentPlan.FindAll("c"))
                builder.AddBlock("block-crate",c,1);

            foreach (var c in currentPlan.FindAll("b"))
                builder.AddPushableBlock("block-garbage", c);

            var platform = RoomPlans.Get(typeof(SubwayPlatformLG).Name);
            builder.AddRoomTransition(typeof(SubwayPlatformLG), currentPlan.Find("d0"), platform.Find("d0").Left);

            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

            builder.AutomaticWall("wall-tunnel");
        }
    }
}
