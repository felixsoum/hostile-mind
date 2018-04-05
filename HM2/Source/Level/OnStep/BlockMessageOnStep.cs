using System;

namespace HostileMind
{
	public class BlockMessageOnStep : OnStepCommand
    {
		string roomName;
		RoomIndex index;
		Block.BlockMessage m;

		public BlockMessageOnStep(string roomName, RoomIndex index, Block.BlockMessage m)
        {
			this.roomName = roomName;
			this.index = index;
			this.m = m;
        }

		public void OnStep()
		{
			GameInfo.CurrentLevel.SendMessage(roomName, index, m);
		}

        public OnStepCommand Clone()
        {
            var clone = new BlockMessageOnStep(roomName, index, m);
            return clone;
        }
    }
}

