using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
	public class SubwayLevel : Level
    {
		public override void Load()
		{
			HouseTextures.Load();
            SubwayTextures.Load();
            
			AddRoom(new SubwayProxyRoom());
            AddRoom(new SubwayPlatformLG());
            AddRoom(new SubwayTunnelLG());
            AddRoom(new SubwayMaintHallway1());
            AddRoom(new SubwayMaintHallway2());
            AddRoom(new SubwayMaintHallway3());
            AddRoom(new SubwayMaintHallway4());
            AddRoom(new SubwayMaintRoom1());
            AddRoom(new SubwayMaintRoom2());
            AddRoom(new SubwayMaintRoom3());
            AddRoom(new SubwayMaintRoom4());
            AddRoom(new SubwayFurnaceRoom());
            AddRoom(new SubwaySecretRoom());
            AddRoom(new SubwayStreet());
            AddRoom(new SubwayPuzzleRoom());

            PlayerActor.Instance.Position = new Vector2(5 * GameInfo.TILE_X, 5 * GameInfo.TILE_Y);
            
		}

        public override Level Clone()
        {
            return new SubwayLevel();
        }

        public override void Lose()
        {
            GameDirector.TransitionTo(new GameOverL3());
        }
    }
}

