using System;

namespace HostileMind
{
	public class FinalCaseConcordia1 : Room
    {
        private const string ROCK_TEXT = "Rubble from the terrorist bombing.";
        //
        private bool bridgeMsg = false;

        public FinalCaseConcordia1()
        {
            var builder = new RoomBuilder(this);

            //FLOORS

            builder.FillFloor("floor-platform-GC");
            builder.FillFloor("floor-test", currentPlan.Find("dy"), 1, 1); //debug
            //stairs
            builder.FillFloor("floor-hstairs", currentPlan.Find("d0"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("d12"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s1"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s2"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s3"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s4"), 2, 4);

            //WALLS

            //metal wall
            builder.AddWall("wall-metal", currentPlan.Find("w0"));
            builder.AddWall("wall-metal", currentPlan.Find("w1"));
            builder.AddWall("wall-metal", currentPlan.Find("w2"));
            //bridge rail
            builder.AddWall("wall-bridge-rail", 15, 33, 8);//9
            builder.AddWall("wall-bridge-rail", 15, 33, 19);
            builder.AddWall("wall-bridge-rail", 7, 8, 8);
            builder.AddWall("wall-bridge-rail", 7, 8, 19);
            //normal wall
            builder.AddWall("wall-concordia", 1, 4, 3);
            //map on wall
            builder.AddWall("wall-concordia-map", 33, 34, 3);

            //BLOCKS

            foreach (var p in currentPlan.FindAll("p"))
                builder.AddPushableBlock("stone-brown", p);
            foreach (var b in currentPlan.FindAll("r"))
                builder.AddBlock("block-debris", b, 1, ROCK_TEXT);

            //ITEMS

            builder.AddItemTile(Item.ItemType.BOTTLE, currentPlan.Find("i0"));

            //EVENTS

            foreach (var e0 in currentPlan.FindAll("e0"))
                builder.AddDialogToTile(
                    "This is the metro's exit. If I go back now, \nI won't be able to enter the metro again.", e0);
            foreach (var e1 in currentPlan.FindAll("e1"))
                builder.AddDialogToTile("The bridge is broken", e1);
            //
            foreach (var m in currentPlan.FindAll("m"))
            builder.AddDialogToTile(
                    "According to the map, I should go to Peel Station.", currentPlan.Find("m"));

            //TRANSITIONS

            //back to proxy room
            var proxy = RoomPlans.Get(typeof(FinalCaseProxyRoom).Name);
            builder.AddRoomTransition(typeof(FinalCaseProxyRoom), currentPlan.Find("dy"), proxy.Find("d0").Bottom);

            //to concordia-2 (bottom right stairs)
            var c2br = RoomPlans.Get(typeof(FinalCaseConcordia2).Name);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d0"), c2br.Find("d0").Left);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d1"), c2br.Find("d1").Left);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d2"), c2br.Find("d2").Left);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d3"), c2br.Find("d3").Left);

            //to concordia-2 (top left stairs)
            var c2tl = RoomPlans.Get(typeof(FinalCaseConcordia2).Name);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d4"), c2tl.Find("d4").Right);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d5"), c2tl.Find("d5").Right);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d6"), c2tl.Find("d6").Right);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d7"), c2tl.Find("d7").Right);

            //to concordia-2 (bottom left stairs)
            var c2bl = RoomPlans.Get(typeof(FinalCaseConcordia2).Name);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d8"), c2bl.Find("d8").Right);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d9"), c2bl.Find("d9").Right);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d10"), c2bl.Find("d10").Right);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d11"), c2bl.Find("d11").Right);

            //to concordia-2 (top right stairs)
            var c2tr = RoomPlans.Get(typeof(FinalCaseConcordia2).Name);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d12"), c2tr.Find("d12").Left);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d13"), c2tr.Find("d13").Left);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d14"), c2tr.Find("d14").Left);
            builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d15"), c2tr.Find("d15").Left);

            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

        }
    }
}

