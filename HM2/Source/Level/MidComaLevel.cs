using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
	public class MidComaLevel : Level
	{
//		private Cutscene cutscene;
//
//		public MidComaLevel(Cutscene cutscene)
//		{
//            isHidingPlayer = true;
//			this.cutscene = cutscene;
//		}
//
//		public override void Load()
//		{
//			Textures.Load("floor-marble");
//			Textures.Load("wall-beige");
//
//            AddRoom(new MidLevelHospitalRoom(cutscene.doctor));
//
//            cutscene.doctor.Position = new Vector2(100, 100);
//			CutsceneServant.Set(this, cutscene);
//			Renderer.IsFrameActive = false;
//		}

        private Cutscene cutscene;

        public MidComaLevel(Cutscene cutscene)
        {
            this.cutscene = cutscene;
        }

        public override void Load()
        {
            Textures.Load("floor-marble");
            Textures.Load("wall-beige");

            AddRoom(new MidLevelHospitalRoom());

            var player = PlayerActor.Instance;
            player.Position = new Vector2(100, 100);
            CutsceneServant.Set(this, cutscene);
            Renderer.IsFrameActive = false;

        }

        public override Level Clone()
        {
            return new MidComaLevel(cutscene);
        }

        public override void Lose()
        {
            GameDirector.TransitionTo(new GameOverL1WifePath());
        }
	}
}

