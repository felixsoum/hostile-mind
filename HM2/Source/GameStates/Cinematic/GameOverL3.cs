using System;

namespace HostileMind
{
    public class GameOverL3 : CinematicState
    {
        public override void Load()
        {
            base.Load();
            Textures.Load("cinematic-gameover-subway1");


            AddImage(new Sprite(Textures.Get("cinematic-gameover-subway1")));
            AddText("Karen...no...");
            AddWait(2000);
            AddText("I've failed you...");
            AddWait(2000);
            AddText("I couldn't figure out who killed you.");
            AddWait(2000);
            ClearText();

        }

        protected override void OnEnd()
        {
            GameDirector.TransitionTo(new TutorialCinematic());
        }
    }
}