using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    class SubwayMaintHallway2 : Room
    {
        public SubwayMaintHallway2()
        {
            IsCloneable = true;
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-concrete-test");

            foreach (var c in currentPlan.FindAll("d1"))
                builder.FillFloor("floor-hstairs", c);

            foreach (var c in currentPlan.FindAll("c"))
                builder.AddBlock("block-crate", c, 1);


            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

            

            var mainthallway1 = RoomPlans.Get(typeof(SubwayMaintHallway1).Name);
            builder.AddRoomTransition(typeof(SubwayMaintHallway1), currentPlan.Find("d0"), mainthallway1.Find("d2").Bottom);
            builder.AddRoomTransition(typeof(SubwayMaintHallway1), currentPlan.Find("d1"), mainthallway1.Find("d3").Bottom);

            var mainthallway3 = RoomPlans.Get(typeof(SubwayMaintHallway3).Name);
            builder.AddRoomTransition(typeof(SubwayMaintHallway3), currentPlan.Find("d2"), mainthallway3.Find("d0").Top);
            builder.AddRoomTransition(typeof(SubwayMaintHallway3), currentPlan.Find("d3"), mainthallway3.Find("d1").Top);

            var maintRoom2 = RoomPlans.Get(typeof(SubwayMaintRoom2).Name);
            builder.AddRoomTransition(typeof(SubwayMaintRoom2), currentPlan.Find("d6"), maintRoom2.Find("d0").Right);
            builder.AddWall("wall-tunnel",currentPlan.Find("d6"));

            var furnaceRoom = RoomPlans.Get(typeof(SubwayFurnaceRoom).Name);
            builder.AddRoomTransition(typeof(SubwayFurnaceRoom), currentPlan.Find("d4"), furnaceRoom.Find("d0").Left);
            builder.AddWall("wall-tunnel", currentPlan.Find("d4"));

            foreach (var w in currentPlan.FindAll("w"))
                builder.AddWall("wall-tunnel",w);

            builder.AddLinkedItemLockedDoor(currentPlan.Find("d2"), DoorSprite.Orientation.DOWN, Item.ItemType.BOLTCUTTERS, "The door is chained shut, I need some bolt cutters.",
                                            currentPlan.Find("d3"), DoorSprite.Orientation.DOWN, Item.ItemType.BOLTCUTTERS, "The door is chained shut, I need some bolt cutters.",
                                            "door-beatup-1", "door-beatup-2");

            builder.AddLightSource(currentPlan.Find("l1"), 4f);
            builder.AddLightSource(currentPlan.Find("l2"), 4f);
            IsLightingEnabled = false;

            //add enemies
            var enemy1 = new EnemyActor();
            enemy1.Position = currentPlan.Find("e1").ToVector();
            enemy1.Ai = new WaypointPatrolAi(new Vector2(-432, 0),
                                            new Vector2(0, 480),
                                            new Vector2(432, 0),
                                            new Vector2(0, -480));
            AddNpc(enemy1);

            var enemy2 = new EnemyActor();
            enemy2.Position = currentPlan.Find("e2").ToVector();
            enemy2.Ai = new WaypointPatrolAi(new Vector2(48, 0),
                                            new Vector2(-48, 0));
            AddNpc(enemy2);

            //builder.AddWall("wall-tunnel",currentPlan.Find("d2");
            //builder.AutomaticWall("wall-tunnel");

            //builder.FillEdges();
        }
    }
}
