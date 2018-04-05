using System;

namespace HostileMind
{
    public class HospitalCinematic : CinematicState
    {
        public override void Load()
        {
            base.Load();
//            Textures.Load("cinematic-car");
//            Sounds.Load("beep-beep");
//            Sounds.Load("car-crash");
//
//            AddImage(new Sprite(Textures.Get("cinematic-car")));
//            AddText("ACT: BEGINNING OF THE END");
//            AddWait(4000);
//            AddText("Logan is on his way to the police station\nbut a traffic jam slows him down");
//            AddSound("beep-beep");
//            AddWait(4000);
//            AddText("Suddenly another driver crashes into his car...");
//            AddSound("car-crash");
//            ClearImage();
//            AddWait(4000);
            AddText("Hospital cutscene");
            AddWait(1000);
        }

        protected override void OnEnd()
        {
            GameDirector.TransitionTo(new HospitalLevel());
        } 
    }
}

