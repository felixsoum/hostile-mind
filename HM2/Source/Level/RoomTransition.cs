using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class RoomTransition
    {
        public string NextRoom { get; private set; }
        public Vector2 NextPlayerPosition { get; private set; }
        public bool IsActive { get; private set; }

        public RoomTransition()
        {
            NextRoom = "";
            NextPlayerPosition = Vector2.Zero;
            IsActive = false;
        }

        public void Activate(string nextRoom, Vector2 nextPlayerPosition)
        {
            NextRoom = nextRoom;
            NextPlayerPosition = nextPlayerPosition;
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}

