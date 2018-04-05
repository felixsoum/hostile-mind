using System;

namespace HostileMind
{
    public class DriftingCinematic : CinematicState
    {
        public override void Load()
        {
            base.Load();
            
            AddText("Logan: Karen... No... This can't be happening...");
            AddWait(4000);
            AddText("???: Logan?");
            AddText("Logan: I'm sorry... Karen... I'm so sorry...");
            AddWait(4000);
            AddText("???: Logan? Can you hear me?");
            AddWait(4000);
            AddText("Logan: I'M SORRY!!!");
            AddWait(4000);
            AddText("LOGAN, SNAP OUT OF IT!!!");
            
            //ClearImage();
            AddWait(4000);
            AddText("... ... ...");
            AddWait(1000);
        }

        protected override void OnEnd()
        {
            GameDirector.TransitionTo(new HouseLevel());
        }
    }
}

