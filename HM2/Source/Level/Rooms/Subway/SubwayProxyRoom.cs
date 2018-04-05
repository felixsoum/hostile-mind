using System;

namespace HostileMind
{
	public class SubwayProxyRoom : Room
    {
        public SubwayProxyRoom()
        {
			var builder = new RoomBuilder(this);

            builder.FillFloor("floor-concrete-test");
			builder.FillFloor("floor-road-large-vertical",1,1,10,10);

            //builder.AddBlock("block-crate", currentPlan.Find("p"), 1,onChoice,"You should go down to the metro, your new partner is waiting for you");
            builder.AddBlock("npc-stm", currentPlan.Find("p"), 1, onChoice, "Speak to the officer.", "Ignore him.");
			//builder.AddWall("wall-beige", 1, 13, 1);
			//builder.AddWall("wall-beige", currentPlan.Find("d0"));
//			builder.AddChoice(EndChoice, "Go to hospital", "Go to final case", currentPlan.Find("d0"));

            var next = RoomPlans.Get(typeof(SubwayPlatformLG).Name);
            builder.AddRoomTransition(typeof(SubwayPlatformLG),currentPlan.Find("d1"),next.Find("d1").Right);

            

			builder.FillEdges();
            CutsceneServant.Set(GameInfo.CurrentLevel, new SubwayStartCutscene());
		}

        public void onChoice(int x)
        {
            if (x == 1)
            {
                
                CutsceneServant.Set(GameInfo.CurrentLevel, new SubwayStartCutscene());
            }
            else
                Dialog.SetText("I really don't want to talk to him, \nbut I have to find out what's going on...");
            return;
        }
		public void EndChoice(int x)
		{
			switch (x)
			{
				case 1:
					GameDirector.TransitionTo(new MidComaLevel(new MidComaHospitalCutscene()));
					break;
				default:
					GameDirector.TransitionTo(new MidComaLevel(new MidComaFinalCaseCutscene()));
					break;
			}
		}
	}
}


