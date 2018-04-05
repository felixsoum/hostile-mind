using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
	public class EndingLevel : Level
    {
		public override void Load()
		{
			HouseTextures.Load();

			AddRoom(new EndingProxyRoom());

			PlayerActor.Instance.Position = new Vector2(128, 128);
		}

        public override Level Clone()
        {
            return new EndingLevel();
        }

        public override void Lose()
        {
            GameDirector.TransitionTo(new GameOverL1WifePath());
        }
    }
}

