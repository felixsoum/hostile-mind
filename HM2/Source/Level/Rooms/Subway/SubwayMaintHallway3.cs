using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    class SubwayMaintHallway3 : Room
    {
        public SubwayMaintHallway3()
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-concrete-test");

            foreach (var c in currentPlan.FindAll("d1"))
                builder.FillFloor("floor-hstairs", c);

            foreach (var c in currentPlan.FindAll("c"))
                builder.AddBlock("block-crate", c, 1);


            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

            //var tunnel = RoomPlans.Get(typeof(SubwayTunnelLG).Name);
            //builder.AddRoomTransition(typeof(SubwayTunnelLG), currentPlan.Find("d0"), tunnel.Find("d0").Bottom);
            //builder.AddRoomTransition(typeof(SubwayTunnelLG), currentPlan.Find("d1"), tunnel.Find("d1").Bottom);

            //builder.AutomaticWall("wall-tunnel");

            var mainthallway2 = RoomPlans.Get(typeof(SubwayMaintHallway2).Name);
            builder.AddRoomTransition(typeof(SubwayMaintHallway2), currentPlan.Find("d0"), mainthallway2.Find("d2").Bottom);
            builder.AddRoomTransition(typeof(SubwayMaintHallway2), currentPlan.Find("d1"), mainthallway2.Find("d3").Bottom);

            var mainthallway4 = RoomPlans.Get(typeof(SubwayMaintHallway4).Name);
            builder.AddRoomTransition(typeof(SubwayMaintHallway4), currentPlan.Find("d2"), mainthallway4.Find("d0").Top);
            builder.AddRoomTransition(typeof(SubwayMaintHallway4), currentPlan.Find("d3"), mainthallway4.Find("d1").Top);

            var maintroom3 = RoomPlans.Get(typeof(SubwayMaintRoom3).Name);
            builder.AddRoomTransition(typeof(SubwayMaintRoom3), currentPlan.Find("d4"), maintroom3.Find("d0").Left);

            var maintroom4 = RoomPlans.Get(typeof(SubwayMaintRoom4).Name);
            builder.AddRoomTransition(typeof(SubwayMaintRoom4), currentPlan.Find("d5"), maintroom4.Find("d0").Right);

            builder.AddLightSource(currentPlan.Find("l1"), 3.5f);
            builder.AddLightSource(currentPlan.Find("l2"), 3.5f);
            builder.AddLightSource(currentPlan.Find("l3"), 3.5f);
            builder.AddLightSource(currentPlan.Find("l4"), 3.5f);
            builder.AddLightSource(currentPlan.Find("l5"), 3.5f);
            builder.AddLightSource(currentPlan.Find("l6"), 3.5f);

            IsLightingEnabled = false;

            builder.FillEdges();

            builder.AutomaticWall("wall-tunnel");


            //add enemies
            var enemy1 = new EnemyActor();
            enemy1.Position = currentPlan.Find("e1").ToVector();
            enemy1.Ai = new WaypointPatrolAi(new Vector2(-720, 0),
                                            new Vector2(0, 576),
                                            new Vector2(720, 0),
                                            new Vector2(0, -576));
            AddNpc(enemy1);

            var enemy2 = new EnemyActor();
            enemy2.Position = currentPlan.Find("e2").ToVector();
            enemy2.Ai = new WaypointPatrolAi(new Vector2(720, 0),
                                            new Vector2(0, -576),
                                            new Vector2(-720, 0),
                                            new Vector2(0, 576));
            AddNpc(enemy2);
        }
    }
}

