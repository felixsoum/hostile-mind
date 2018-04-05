using System;

namespace HostileMind
{
    public class IntroCinematic : CinematicState
    {
        public override void Load()
        {
            base.Load();
            Textures.Load("logo-eye");
            Sounds.Load("carrot");

            AddImage(new Sprite(Textures.Get("logo-eye")));
            AddText("HOSTILE MIND");
            AddWait(2000);
            AddText("A GAME DEVELOPPED BY TEAM SIX");
            AddWait(2000);
            ClearText();
            AddSound("carrot");
        }

        protected override void OnEnd()
        {
			GameDirector.TransitionTo(new TutorialCinematic());
        }
    }
}

