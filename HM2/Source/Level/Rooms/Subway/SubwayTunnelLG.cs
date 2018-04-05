using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    class SubwayTunnelLG : Room
    {
        
        public SubwayTunnelLG()
        {
            IsCloneable = true;

            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-concrete-test");

            
            builder.FillFloor("floor-hstairs", currentPlan.Find("s1"));
            builder.AddWall("wall-tunnel",currentPlan.Find("s1"));
            //builder.FillFloor("floor-hstairs", currentPlan.Find("s2"));
            builder.ClearFloor(currentPlan.Find("s2"));
            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

            foreach (var c in currentPlan.FindAll("w"))
                builder.AddWall("wall-tunnel", c);

            builder.AddPushableItemBlock("stone-sphere", currentPlan.Find("c"), Item.ItemType.POLE, "I need something to help me move the boulder.");

            builder.AddItemTile(Item.ItemType.KEY, currentPlan.Find("k"));
            builder.AddItemTile(Item.ItemType.POLE, currentPlan.Find("p"));
            var platform = RoomPlans.Get(typeof(SubwayPlatformLG).Name);
            builder.AddRoomTransition(typeof(SubwayPlatformLG), currentPlan.Find("s1"), platform.Find("s1").Left);
            //builder.AddRoomTransition(typeof(SubwayPlatformLG), currentPlan.Find("s2"), platform.Find("s2").Left);

            var mainthallway1 = RoomPlans.Get(typeof(SubwayMaintHallway1).Name);
            builder.AddRoomTransition(typeof(SubwayMaintHallway1), currentPlan.Find("d1"), mainthallway1.Find("d1").Top);

            var maintroom1 = RoomPlans.Get(typeof(SubwayMaintRoom1).Name);
            builder.AddRoomTransition(typeof(SubwayMaintRoom1), currentPlan.Find("d2"), maintroom1.Find("d2").Top);
            builder.AddRoomTransition(typeof(SubwayMaintRoom1), currentPlan.Find("d3"), maintroom1.Find("d3").Top);

            builder.AddLinkedItemLockedDoor(currentPlan.Find("d2"), DoorSprite.Orientation.DOWN, Item.ItemType.KEY, "The door is locked",
                                            currentPlan.Find("d3"), DoorSprite.Orientation.DOWN, Item.ItemType.KEY, "The door is locked",
                                            "door-beatup-1", "door-beatup-2");

            var enemy = new EnemyActor();
            enemy.Position = currentPlan.Find("e1").ToVector();
            enemy.Ai = new WaypointPatrolAi(new Vector2(-800, 0),
                                            new Vector2(0, 150),
                                            new Vector2(800, 0),
                                            new Vector2(-0, -150));
            AddNpc(enemy);
            builder.AddLightSource(currentPlan.Find("l1"), 5f);
            builder.AddLightSource(currentPlan.Find("l2"), 5f);
            IsLightingEnabled = false;
            //builder.FillEdges();
        }

        public void setLightsOff()
        {
            IsLightingEnabled = true;
        }
        public override Room Clone()
        {
            return new SubwayTunnelLG();
        }

        //public override void Update()
        //{
        //    base.Update();
            
        //}
    }
}