using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HostileMind
{
    public abstract class Level
    {
        public string Name { get; set; }
        public Room CurrentRoom { get; private set; }
        private IDictionary<string, Room> rooms = new Dictionary<string, Room>();
        public RoomTransition RoomTransition { get; set; }
        public List<CutsceneAction> Cutscene = new List<CutsceneAction>();
//        private Room clonedRoom = null;
//        private Vector2 clonedPosition = Vector2.Zero;
//        private List<Item> clonedItems = new List<Item>();
        public abstract Level Clone();
        public abstract void Lose();
        public bool isHidingPlayer = false;

        public Level()
        {
            Name = GetType().Name;
            CurrentRoom = null;
            RoomTransition = new RoomTransition();
        }

        public void NotifyLoad()
        {
            Util.Seed();
            Load();
        }

        public virtual void Load()
        {
        }

        public void NotifyRoomCreation()
        {
            foreach (var room in rooms.Values)
                room.OnRoomCreation(this);
        }

        public void NotifyLose()
        {
            PlayerActor.Instance.CompleteReset();
            Lose();
        }

        public void Update()
        {
            if (Inputs.IsPressed(Keys.R))
            {
                if (!GameDirector.IsTransitioning())
                {
                    if (!GameInfo.IsGodModeEnabled)
                    {
                        PlayerActor.Instance.LifeCount--;
                    }

                    if (PlayerActor.Instance.LifeCount > 0)
                        GameDirector.TransitionTo(new RetryCinematic(Clone()));
                    else
                        GameInfo.CurrentLevel.NotifyLose();
                }
//                var nextClone = clonedRoom.Clone();
//                CurrentRoom = clonedRoom;
//                clonedRoom = nextClone;
//
//                var nextPosition = clonedPosition;
//                PlayerActor.Instance.Position = clonedPosition;
//                clonedPosition = nextPosition;
//
//                var nextItems = PlayerItems.Get();
//                PlayerItems.Set(clonedItems);
//                clonedItems = nextItems;
            }
            CurrentRoom.Update();
            while (Cutscene.Count > 0)
            {
                if (Cutscene[0].Act())
                    Cutscene.RemoveAt(0);
                else
                    break;
            }
        }

        public void Draw()
        {
            CurrentRoom.Draw();
        }

        public void AddRoom(Room room)
        {
            if (CurrentRoom == null)
                CurrentRoom = room;
            rooms.Add(room.Name, room);
        }

        public T GetRoom<T>(Type type) where T : Room
        {
            Room room;
            if (rooms.TryGetValue(type.Name, out room))
                return (T)room;

            return null;
        }

        public void TransitionTo(string roomName, Vector2 playerPosition)
        {
            Room room;
            if (rooms.TryGetValue(roomName, out room))
            {
                var previousRoom = CurrentRoom;

//                if (room.IsCloneable)
//                {
//                    clonedRoom = room.Clone();
//                    clonedPosition = playerPosition;
//                    clonedItems = PlayerItems.Get();
//                }

                CurrentRoom = room;
                CurrentRoom.OnTransition(previousRoom);
                PlayerActor.Instance.Position = playerPosition;
                CurrentRoom.Update();
            }
            else
            {
                Console.WriteLine("Room " + roomName + " does not exist!");
            }
        }

        public void ActivateRoomTransition()
        {
            TransitionTo(RoomTransition.NextRoom, RoomTransition.NextPlayerPosition);
        }

		public void SendMessage(string roomName, RoomIndex index, Block.BlockMessage m)
		{
			Room room;
			rooms.TryGetValue(roomName, out room);
			var tile = room.GetTile(index);
			tile.OnMessage(m);
		}
    }
}

