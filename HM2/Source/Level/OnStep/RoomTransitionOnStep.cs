using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class RoomTransitionOnStep : OnStepCommand
    {
        private string roomName;
        private Vector2 targetPosition;

        public RoomTransitionOnStep(string roomName, Vector2 playerPosition)
        {
            this.roomName = roomName;
            this.targetPosition = playerPosition;
        }

        public void OnStep()
        {
            GameInfo.CurrentLevel.RoomTransition.Activate(roomName, targetPosition);
        }

        public OnStepCommand Clone()
        {
            var clone = new RoomTransitionOnStep(roomName, targetPosition);
            return clone;
        }
    }
}

