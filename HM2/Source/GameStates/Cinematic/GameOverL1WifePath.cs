using System;

namespace HostileMind
{
    public class GameOverL1WifePath : CinematicState
    {
        public override void Load()
        {
            base.Load();
            Textures.Load("cinematic-gameover-wife");
            

            AddImage(new Sprite(Textures.Get("cinematic-gameover-wife")));
            AddText("Karen...no...");
            AddWait(2000);
            AddText("I couldn't save you..");
            AddWait(2000);
            AddText("I failed..");
            AddWait(2000);
            ClearText();
            
        }

        protected override void OnEnd()
        {
            GameDirector.TransitionTo(new TutorialCinematic());
        }
    }
}