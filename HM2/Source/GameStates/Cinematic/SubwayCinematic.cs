using System;

namespace HostileMind
{
    public class SubwayCinematic : CinematicState
    {
        public override void Load()
        {
            base.Load();
            Textures.Load("cinematic-subway-1");

            AddImage(new Sprite(Textures.Get("cinematic-subway-1")));
            AddText("ACT: THE PARTNER");
            AddWait(3000);
        }

        protected override void OnEnd()
        {
            GameDirector.TransitionTo(new SubwayLevel());
        } 
    }
}

