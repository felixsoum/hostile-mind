using System;

namespace HostileMind
{
	public class FinalCaseProxyRoom : Room
    {
        public FinalCaseProxyRoom()
        {
			var builder = new RoomBuilder(this);

			builder.FillFloor("floor-marble");
			//builder.AddWall("wall-beige", 1, 6, 1);
            //builder.AddWall("wall-beige", 8, 13, 1);
			//builder.AddWall("wall-beige", currentPlan.Find("dx"));

            builder.AddWall("wall-beige", 1, 2, 1);
            builder.AddWall("wall-beige", 4, 5, 1);
            builder.AddWall("wall-beige", 7, 8, 1);
            builder.AddWall("wall-beige", 10, 13, 1);
            //path to next level
            builder.AddWall("wall-beige", currentPlan.Find("dx"));


            //to concordia
            var con = RoomPlans.Get(typeof(FinalCaseConcordia1).Name);
            builder.AddRoomTransition(typeof(FinalCaseConcordia1), currentPlan.Find("d0"), con.Find("dy").Bottom);
            //peel
            var peel = RoomPlans.Get(typeof(FinalCasePeel).Name);
            builder.AddRoomTransition(typeof(FinalCasePeel), currentPlan.Find("d1"), peel.Find("d0").Right);
            //mg
            //var mg = RoomPlans.Get(typeof(FinalCaseMcgill).Name);
            //builder.AddRoomTransition(typeof(FinalCaseMcgill), currentPlan.Find("d2"), mg.Find("d0").Right);

            //next level (creates tile on floor)
			builder.AddStateTransition(new LevelState(new EndingLevel()), currentPlan.Find("dx"));

			builder.FillEdges();
        }
    }
}

