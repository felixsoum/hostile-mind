using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
	public class HospitalProxyRoom : Room
    {
        public HospitalProxyRoom()
        {
			var builder = new RoomBuilder(this);

			builder.FillFloor("floor-carpet");

			builder.FillFloor("floor-test", currentPlan.Find("f"), 6, 5);

			builder.AddWall("wall-beige", 1, 13, 1);
			builder.AddWall("wall-beige", currentPlan.Find("d0"));
			builder.AddChoice(EndChoice, "Go to subway", "Go to final case", currentPlan.Find("d0"));

			

            var hallway = RoomPlans.Get(typeof(HospitalLoganStart).Name);
            builder.AddRoomTransition(typeof(HospitalLoganStart), currentPlan.Find("d1"), hallway.Find("d1").Top);

            var laundryRoom = RoomPlans.Get(typeof(HospitalBasementLaundryRoom).Name);
            builder.AddRoomTransition(typeof(HospitalBasementLaundryRoom), currentPlan.Find("d2"), laundryRoom.Find("d0").Left);

            var main = RoomPlans.Get(typeof(HospitalMainHallway).Name);
            builder.AddRoomTransition(typeof(HospitalMainHallway), currentPlan.Find("d3"), main.Find("e1").Bottom);

			builder.FillEdges();
        }

		public void EndChoice(int x)
		{
			switch (x)
			{
				case 1:
					GameDirector.TransitionTo(new MidComaLevel(new MidComaSubwayCutscene()));
					break;
				default:
					GameDirector.TransitionTo(new MidComaLevel(new MidComaFinalCaseCutscene()));
					break;
			}
		}
    }
}

