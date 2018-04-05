using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
	public class HospitalLevel : Level
    {
      
        public override void Load()
		{
			

            HouseTextures.Load();
            HospitalTextures.Load();

            //5th Floor Rooms
			//AddRoom(new HospitalProxyRoom());
            AddRoom(new HospitalLoganStart());
            AddRoom(new Hospital5thFloorHallway());
            AddRoom(new Hospital5thFloorExplore1());
            AddRoom(new Hospital5thFloorExplore2());
            AddRoom(new Hospital5thFloorExplore3());
            AddRoom(new Hospital5thFloorExplore4());
            AddRoom(new Hospital5thFloorUtilityRoom());
            AddRoom(new Hospital5thFloorKeyRoom1());
            AddRoom(new Hospital5thFloorKeyRoom2());
            AddRoom(new Hospital5thFloorKeyRoom3());
            AddRoom(new Hospital5thFloorDoctorRoom());
            AddRoom(new HospitalElevator());
            
            //Basement Floor Rooms
            AddRoom(new HospitalBasementHallway());
            AddRoom(new HospitalBasementLaundryRoom());
            AddRoom(new HospitalBasementUtilityRoom());
            AddRoom(new HospitalBasementSwitchRoom());
            AddRoom(new HospitalBasementKeyRoom1());
            AddRoom(new HospitalBasementKeyRoom2());
            AddRoom(new HospitalBasementBreakerRoom());
            
            //Main Floor Rooms
            AddRoom(new HospitalMainHallway());
            AddRoom(new HospitalMainStaffRoom());
            AddRoom(new HospitalMainWashRoom());
            AddRoom(new HospitalMainUtilityRoom());
            AddRoom(new HospitalMainSpareRoom());
            AddRoom(new HospitalMainCurtainRoom1());
            AddRoom(new HospitalMainCurtainRoom2());
            AddRoom(new HospitalMainCurtainRoom3());
            AddRoom(new HospitalMainExteriorRoom());

			PlayerActor.Instance.Position = new Vector2(128, 128);
		}

        public override Level Clone()
        {
            return new HospitalLevel();
        }

        public override void Lose()
        {
            GameDirector.TransitionTo(new GameOverL1WifePath());
        }
    }
}

