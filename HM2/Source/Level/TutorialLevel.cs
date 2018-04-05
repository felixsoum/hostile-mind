using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
	public class TutorialLevel : Level
    {
		public override void Load()
		{
			HouseTextures.Load();

            AddRoom(new MasterBedRoom(true));
            AddRoom(new HouseHallwayTwoRoom(true));
            AddRoom(new ClosetRoom2(true));
            AddRoom(new CrawlSpaceRoom());
			AddRoom(new BathRoom2(true));
			AddRoom(new ClosetRoom3());
			AddRoom(new LaundryRoom(true));
			AddRoom(new RecRoom(true));

			PlayerActor.Instance.Position = new Vector2(330, 80);
            CutsceneServant.Set(this, new TutorialCutscene1());
		}

        public override Level Clone()
        {
            return new TutorialLevel();
        }

        public override void Lose()
        {
            GameDirector.TransitionTo(new GameOverL1WifePath());
        }
    }
}

