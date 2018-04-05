using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class HouseLevel : Level
    {
        public override void Load()
        {
            HouseTextures.Load();
            Sounds.Load("gun-shot");

            var hallwayOne = new HouseHallwayOneRoom();
            var shadow = new ShadowActor();
            shadow.Orient(Actor.Orientation.LEFT);
            AddRoom(hallwayOne);
            AddRoom(new HouseHallwayTwoRoom());
            AddRoom(new KitchenRoom());
            AddRoom(new StorageRoom());
            AddRoom(new DiningRoom());
            AddRoom(new LivingRoom(shadow));
            AddRoom(new GuestRoom());
            AddRoom(new BathRoom());
            AddRoom(new ClosetRoom());
            AddRoom(new ClosetRoom2());
            AddRoom(new LockedRoom());
            AddRoom(new CrawlSpaceRoom());
            AddRoom(new MasterBedRoom());
            AddRoom(new BathRoom2());
            AddRoom(new ClosetRoom3());
            AddRoom(new LaundryRoom());
            AddRoom(new RecRoom());
            AddRoom(new OutsideRoom());
            
            PlayerActor.Instance.Position = hallwayOne.GetPlayerStart();
            PlayerActor.Instance.Orient(Actor.Orientation.UP);
            CutsceneServant.Set(this, new WifeCutscene(shadow));
        }

        public override Level Clone()
        {
            return new HouseLevel();
        }

        public override void Lose()
        {
            GameDirector.TransitionTo(new GameOverL1WifePath());
        }
    }
}

