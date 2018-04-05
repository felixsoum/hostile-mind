using System;

namespace HostileMind
{
    public class FinalCasePeelMcgill : Room
    {
        private const string ROCK_TEXT = "I'm just glad none of these fell on me. ";

        public FinalCasePeelMcgill()
        {
            var builder = new RoomBuilder(this);

            //FLOOR

            //concrete
            builder.FillFloor("floor-concrete-old", currentPlan.Find("c0"), 134, 1); //178
            builder.FillFloor("floor-concrete-old", currentPlan.Find("c1"), 134, 1);
            //tracks
            builder.FillFloor("floor-htracks", currentPlan.Find("f0"), 134, 5); //178
            builder.FillFloor("floor-htracks", currentPlan.Find("f1"), 134, 5);

            //WALLS

            builder.AddWall("wall-tunnel", 1, 134, 2);
            //lights
            for (int i = 0; i < 7; i++) //9 (max)
                builder.AddWall("wall-tunnel2", 1 + 22 * i, 1 + 22 * i + 1, 2);
            //signs
            for (int i = 0; i < 6; i++) //8 (max-1)
                builder.AddWall("wall-tunnel3", 1 + 11 + 22 * i, 1 + 11 + 22 * i + 1, 2);

            //BLOCKS
            foreach (var p in currentPlan.FindAll("p"))
                builder.AddPushableBlock("stone-brown", p);
            foreach (var r in currentPlan.FindAll("r"))
                builder.AddBlock("block-debris", r, 1, ROCK_TEXT);

            //TRANSITIONS

            //back to peel
            var peel = RoomPlans.Get(typeof(FinalCasePeel).Name);
            builder.AddRoomTransition(typeof(FinalCasePeel), currentPlan.Find("d0"), peel.Find("d1").Left);

            //to mcgill
            var mcgill = RoomPlans.Get(typeof(FinalCaseMcgill).Name);
            builder.AddRoomTransition(typeof(FinalCaseMcgill), currentPlan.Find("d1"), mcgill.Find("d0").Right);

            //to concordia-2 (bottom right)
            //var c2br = RoomPlans.Get(typeof(FinalCaseConcordia2).Name);
            //builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d0"), c2br.Find("d0").Left);
            //builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d1"), c2br.Find("d1").Left);
            //builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d2"), c2br.Find("d2").Left);
            //builder.AddRoomTransition(typeof(FinalCaseConcordia2), currentPlan.Find("d3"), c2br.Find("d3").Left);

            //builder.FillEdges();

            foreach (var c in currentPlan.FindAll("#"))
                builder.ClearFloor(c);

        }
    }
}