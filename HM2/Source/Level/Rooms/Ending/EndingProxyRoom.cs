using System;

namespace HostileMind
{
	public class EndingProxyRoom : Room
    {
        public EndingProxyRoom()
        {
			var builder = new RoomBuilder(this);
			builder.FillFloor("floor-marble");
			builder.AddWall("wall-beige", 1, 13, 1);
			builder.FillEdges();
        }
    }
}

