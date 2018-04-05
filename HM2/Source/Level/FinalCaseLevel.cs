using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
	public class FinalCaseLevel : Level
    {
		public override void Load()
		{
            //load textures
			HouseTextures.Load();
            SubwayTextures.Load();

            //add rooms
			AddRoom(new FinalCaseProxyRoom());
            AddRoom(new FinalCaseConcordia1());
            AddRoom(new FinalCaseConcordia2());
            AddRoom(new FinalCaseConcordiaPeel());
            AddRoom(new FinalCaseTunnelRoom());
            AddRoom(new FinalCasePeel());
            AddRoom(new FinalCasePeelMcgill());
            AddRoom(new FinalCaseMcgill());


			PlayerActor.Instance.Position = new Vector2(128, 128);
		}

        public override Level Clone()
        {
            return new FinalCaseLevel();
        }

        public override void Lose()
        {
            GameDirector.TransitionTo(new GameOverL1WifePath());
        }
    }
}

