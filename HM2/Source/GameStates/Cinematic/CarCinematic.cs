using System;

namespace HostileMind
{
    public class CarCinematic : CinematicState
    {
        public override void Load()
        {
            base.Load();
            Textures.Load("cinematic-car");
            Textures.Load("cinematic-phone");
            Sounds.Load("beep-beep");
            Sounds.Load("car-crash");

            AddImage(new Sprite(Textures.Get("cinematic-phone")));
            AddText("ACT: BEGINNING OF THE END");
            AddWait(2000);
            AddText("Logan is on the phone with the chief of police.");
            AddWait(2000);
            AddText("Chief: Logan, I know you haven't gotten over the death\n"+
                "of your wife and are still eager to find the perpetrator. ");
            AddWait(4000);

            AddText("Chief: So I'm calling to inform you about this new case which\n" +
                "seems to have a connection with Karen's murder. ");
            AddWait(4000);

            AddText("Chief: I've informed your partner, Scott, as well.\n" +
                "I'll be waiting for the two of you in my office. ");
            AddWait(4000);

            AddText("Chief: And Logan? Please do me a favor and stay calm.\nDon't over do it.");
            AddWait(4000);

            AddText("Logan: Don't worry cheif, I will.\nI will be there in a second.");
            AddWait(4000);
            
            ClearImage();

            AddImage(new Sprite(Textures.Get("cinematic-car")));

            AddText("Logan gets to his car and speeds down to the station");
            AddWait(4000);
            
            AddText("He goes fast, eager to here about this case.");
            AddSound("beep-beep");
            AddWait(4000);
            AddText("Suddenly another driver crashes into his car...");
            AddSound("car-crash");
            ClearImage();
            AddWait(4000);
            AddText("Logan: ... ... ...");
            AddWait(1000);
        }

        protected override void OnEnd()
        {
            GameDirector.TransitionTo(new HouseLevel());
        } 
    }
}

