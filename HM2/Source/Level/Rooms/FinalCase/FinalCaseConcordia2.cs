using System;

namespace HostileMind
{
    public class FinalCaseConcordia2 : Room
    {
        private const string ROCK_TEXT = "These rocks are blocking my way.";
        private const string ROCK_TEXT2 = "I can't pass this rubble. \nThis isn't the way to Peel Station anyway.";

        public FinalCaseConcordia2()
        {
            var builder = new RoomBuilder(this);

            builder.FillFloor("floor-platform-GC");
            //stairs
            builder.FillFloor("floor-hstairs", currentPlan.Find("s0"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("s1"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("d4"), 2, 4);
            builder.FillFloor("floor-hstairs", currentPlan.Find("d8"), 2, 4);
            //safety line
            builder.FillFloor("floor-safety-line", currentPlan.Find("b0"), 1, 36);
            builder.FillFloor("floor-safety-line", currentPlan.Find("b1"), 1, 36);
            //tracks
            builder.FillFloor("floor-vtracks", currentPlan.Find("f0"), 5, 40);
            builder.FillFloor("floor-vtracks", currentPlan.Find("f1"), 5, 40);
            //small metro stairs (into tunnel)
            builder.FillFloor("floor-tracks-vstairs", currentPlan.Find("s2"), 1, 1);
            builder.FillFloor("floor-tracks-vstairs", currentPlan.Find("s3"), 1, 1);
            //other concrete
            builder.FillFloor("floor-concrete-old", currentPlan.Find("c0"), 1, 3);
            builder.FillFloor("floor-concrete-old", currentPlan.Find("c1"), 1, 3);
            //debug
            //builder.FillFloor("floor-test", currentPlan.Find("c0"), 1, 1);//


            //WALLS

            builder.AddWall("wall-concordia", 3, 8, 6);
            builder.AddWall("wall-concordia", 21, 26, 6);
            //builder.AddRepeatingBlock("floor-test", currentPlan.Find("m0"), 5, 20);

            //BLOCKS

            foreach (var p in currentPlan.FindAll("p"))
                builder.AddPushableBlock("stone-brown", p);
            foreach (var r in currentPlan.FindAll("r"))
                builder.AddBlock("block-debris", r, 1, ROCK_TEXT);
            foreach (var q in currentPlan.FindAll("q"))
                builder.AddBlock("block-debris", q, 1, ROCK_TEXT2);

            //TRANSITIONS

            //to concordia-1 (bottom right)
            var c1br = RoomPlans.Get(typeof(FinalCaseConcordia1).Name);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d0"), c1br.Find("d0").Right);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d1"), c1br.Find("d1").Right);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d2"), c1br.Find("d2").Right);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d3"), c1br.Find("d3").Right);

            //to concordia-1 (top left)
            var c1tl = RoomPlans.Get(typeof(FinalCaseConcordia1).Name);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d4"), c1tl.Find("d4").Left);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d5"), c1tl.Find("d5").Left);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d6"), c1tl.Find("d6").Left);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d7"), c1tl.Find("d7").Left);

            //to concordia-1 (bottom left)
            var c1bl = RoomPlans.Get(typeof(FinalCaseConcordia1).Name);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d8"), c1bl.Find("d8").Left);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d9"), c1bl.Find("d9").Left);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d10"), c1bl.Find("d10").Left);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d11"), c1bl.Find("d11").Left);

            //to concordia-1 (top right)
            var c1tr = RoomPlans.Get(typeof(FinalCaseConcordia1).Name);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d12"), c1tr.Find("d12").Right);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d13"), c1tr.Find("d13").Right);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d14"), c1tr.Find("d14").Right);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d15"), c1tr.Find("d15").Right);

            //to concordia-peel tunnel
            var cpt = RoomPlans.Get(typeof(FinalCaseConcordiaPeel).Name);
            builder.AddRoomTransition(typeof(FinalCaseConcordiaPeel), currentPlan.Find("d16"), cpt.Find("d0").Right);

            builder.FillEdges();

            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

        }
    }
}

