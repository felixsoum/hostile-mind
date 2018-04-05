using System;

namespace HostileMind
{
    public class SubwayEndingCinematic : CinematicState
    {
        public override void Load()
        {
            base.Load();
            Textures.Load("cinematic-subway-1");

            AddImage(new Sprite(Textures.Get("cinematic-subway-1")));
            AddText("Logan: Was he right? The shooter did reach for something, \nBut was it necessary?");
            AddWait(3000);
            AddText("Logan: I am sure I could have talked him down. ");
            AddWait(3000);
            AddText("Logan: But Scott's reasoning does have some merit...");
            AddWait(3000);
            AddText("Logan: if he genuinely thought we were in danger...\nFor now, I better just get help.");
            
            AddWait(3000);

        }

        protected override void OnEnd()
        {
            GameDirector.TransitionTo(new FinalCaseLevel());
        }
    }
}