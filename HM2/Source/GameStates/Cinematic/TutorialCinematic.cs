using System;

namespace HostileMind
{
    public class TutorialCinematic : CinematicState
    {
        public override void Load()
        {
            base.Load();
            Textures.Load("cinematic-moon");

            AddImage(new Sprite(Textures.Get("cinematic-moon")));
            AddText("ACT: LONELY NIGHT");
            AddWait(4000);
            AddText("<<Cinematics can be skipped by pressing SPACE>>");
            AddWait(4000);
            AddText("Logan: It's been 5 years since that day...\nI could never forget what happened.");
            AddWait(4000);
            AddText("Logan: ... Karen... ...");
            AddWait(1000);
        }

        protected override void OnEnd()
        {
            GameDirector.TransitionTo(new TutorialLevel());
        }  
    }
}

