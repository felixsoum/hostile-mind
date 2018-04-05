using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public struct RoomIndex
    {
        public int I { get; set; }
        public int J { get; set; }

        public RoomIndex Top { get { return new RoomIndex(I, J - 1); } }
        public RoomIndex Bottom { get { return new RoomIndex(I, J + 1); } }
        public RoomIndex Left { get { return new RoomIndex(I - 1, J); } }
        public RoomIndex Right { get { return new RoomIndex(I + 1, J); } }


        public RoomIndex(int i, int j)
            : this()
        {
            I = i;
            J = j;
        }

        public Vector2 ToVector()
        {
            return ToVector(I, J);
        }

        public static Vector2 ToVector(int i, int j)
        {
            return new Vector2(i * GameInfo.TILE_X + GameInfo.TILE_X / 2, j * GameInfo.TILE_Y + GameInfo.TILE_Y / 2);
        }

        public override string ToString()
        {
            return string.Format("[RoomIndex: I={0}, J={1}]", I, J);
        }
    }
}

