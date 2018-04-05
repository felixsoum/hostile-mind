using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    class SubwayMaintHallway4 : Room
    {
        RoomBuilder builder;
        SubwayTunnelLG st;

        public SubwayMaintHallway4()
        {
            builder = new RoomBuilder(this);

            builder.FillFloor("floor-concrete-test");

            foreach (var c in currentPlan.FindAll("d1"))
                builder.FillFloor("floor-hstairs", c);

            foreach (var c in currentPlan.FindAll("c"))
                builder.AddBlock("block-crate", c, 1);


            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

            var maintHallway3 = RoomPlans.Get(typeof(SubwayMaintHallway3).Name);
            builder.AddRoomTransition(typeof(SubwayMaintHallway3), currentPlan.Find("d0"), maintHallway3.Find("d2").Bottom);
            builder.AddRoomTransition(typeof(SubwayMaintHallway3), currentPlan.Find("d1"), maintHallway3.Find("d3").Bottom);


            var secretRoom = RoomPlans.Get(typeof(SubwaySecretRoom).Name);
            builder.AddRoomTransition(typeof(SubwaySecretRoom), currentPlan.Find("d2"), secretRoom.Find("d1").Right);

            var subwayStreet = RoomPlans.Get(typeof(SubwayStreet).Name);
            builder.AddRoomTransition(typeof(SubwayStreet), currentPlan.Find("d3"), subwayStreet.Find("d0").Left);
            builder.AddRoomTransition(typeof(SubwayStreet), currentPlan.Find("d4"), subwayStreet.Find("d1").Left);
            builder.AddLinkedItemLockedDoor(currentPlan.Find("d3"), DoorSprite.Orientation.RIGHT, Item.ItemType.KEYCARD, "I need a keycard to access the service elevator.",
                                            currentPlan.Find("d4"), DoorSprite.Orientation.RIGHT, Item.ItemType.KEYCARD, "I need a keycard to access the service elevator.",
                                            "door-beatup-1", "door-beatup-2");

            var enemy = new EnemyActor();
            enemy.Position = currentPlan.Find("e1").ToVector();
            enemy.Ai = new WaypointPatrolAi(new Vector2(0, 192),
                                            new Vector2(215, 0),
                                            new Vector2(0, -192),
                                            new Vector2(-215, 0));
            AddNpc(enemy);

            var enemy2 = new EnemyActor();
            enemy2.Position = currentPlan.Find("e2").ToVector();
            enemy2.Ai = new WaypointPatrolAi(new Vector2(-215, 0),
                                            new Vector2(0, 192),
                                            new Vector2(215, 0),
                                            new Vector2(0, -192));
            AddNpc(enemy2);
            builder.AddLightSource(currentPlan.Find("l1"), 7.0f);
            builder.AddLightSource(currentPlan.Find("l2"), 7.0f);
            IsLightingEnabled = false;

            builder.AutomaticWall("wall-tunnel");

            
            builder.FillEdges();
        }
        public void setLightsOff()
        {
            IsLightingEnabled = true;
        }
    }
}
