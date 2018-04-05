using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class Room
    {
        public string Name { get; set; }
        public int ColumnCount { get; set; }
        public int RowCount { get; set; }
        protected Tile[,] tiles;
        protected RoomPlan currentPlan = null;
        public bool IsLightingEnabled { get; set; }
        public List<Actor> Npcs { get; set; }
        protected List<LightSource> lights = new List<LightSource>();
        private bool isUpdatedOnce = false;
        public bool IsCloneable { get; set; }

        public Room()
        {
            Name = GetType().Name;
            currentPlan = RoomPlans.Get(Name);
            ColumnCount = currentPlan.ColumnCount;
            RowCount = currentPlan.RowCount;
            Init();
        }

        public Room(int columnCount, int rowCount)
        {
            Name = GetType().Name;
            ColumnCount = columnCount;
            RowCount = rowCount;
            Init();
        }
        
//        public Room(Room room)
//        {
//            Name = room.Name;
//            ColumnCount = room.ColumnCount;
//            RowCount = room.RowCount;
//            tiles = new Tile[ColumnCount, RowCount];
//            for (int i = 0; i < ColumnCount; i++)
//                for (int j = 0; j < RowCount; j++)
//                    tiles[i, j] = room.tiles[i, j].Clone();
//            currentPlan = room.currentPlan;
//			IsLightingEnabled = room.IsLightingEnabled;
//            Npcs = new List<Actor>();
//            // clone npc and clone lights here
//            isUpdatedOnce = room.isUpdatedOnce;
//        }

        public virtual Room Clone()
        {
            return null;
        }

        public virtual void OnRoomCreation(Level level)
        {
        }

        public virtual void OnTransition(Room previousRoom)
        {
        }
        public virtual void Update()
        {
            isUpdatedOnce = true;

            foreach (var tile in tiles)
            {
                tile.Update();
                if (!IsLightingEnabled)
                    continue;

                tile.Light.Minimize();
                foreach (var lightSource in lights){
                    if (lightSource.getOn() == true)
                    {
                        tile.Light.Intensity += lightSource.CalculateIntensity(tile.Position);
                    }
                }
            }

            foreach (var npc in Npcs)
            {
                //                npc.Update();
                if (!IsLightingEnabled)
                    continue;

                npc.Light.Minimize();
                foreach (var lightSource in lights)
                {
                    if (lightSource.getOn() == true)
                    {
                        npc.Light.Intensity += lightSource.CalculateIntensity(npc.Position);
                    }
                }
            }

            // Invoke OnStep on tile that player is on
            var player = PlayerActor.Instance;
            Vector2 playerPos = player.GetHitbox().Center;
            GetTile(playerPos).OnStep();

            if (IsLightingEnabled)
            {
                player.Light.Minimize();
                foreach (var lightSource in lights)
                {
                    if (lightSource.getOn() == true)
                    {
                        player.Light.Intensity += lightSource.CalculateIntensity(player.Position);
                    }
                }
            }
            else
            {
                player.Light.Maximize();
            }
        }

        public void Draw()
        {
            if (!isUpdatedOnce)
                Update();

            for (int i = 0; i < ColumnCount; i++)
                for (int j = 0; j < RowCount; j++)
                    tiles[i, j].Draw();

            foreach (var npc in Npcs)
                npc.Draw();
        }

        public void AddNpc(Actor npc)
        {
            Npcs.Add(npc);
        }
        
        public void RemoveNpc(Actor npc)
        {
            Npcs.Remove(npc);
        }

        public void AddLightSource(LightSource lightSource)
        {
            lights.Add(lightSource);
        }

        public void RemoveLightSource(int index)
        {
            if (lights != null)
            {
                lights.RemoveAt(index);
            }

        }

        public void RemoveLightSource(LightSource lightSource)
        {
            lights.Remove(lightSource);
        }

        public List<LightSource> returnLights()
        {
            return lights;
        }

        public bool IsBlockAt(Vector2 point)
        {
            if (!IsWithinRoom(point))
                return true;

            return GetTile(point).IsBlocked;
        }
        
        public bool IsBlockingVisionAt(Vector2 point)
        {
            if (!IsWithinRoom(point))
                return false;

            return GetTile(point).IsBlocked;
        }

        public bool IsWithinRoom(Vector2 point)
        {
            return point.X >= 0
                && point.Y >= 0
                && (int)point.X / GameInfo.TILE_X < ColumnCount
                && (int)point.Y / GameInfo.TILE_Y < RowCount;
        }

        public void SetTile(Tile tile, int i, int j)
        {
            tiles[i, j] = tile;
        }

        public Tile GetTile(RoomIndex index)
        {
            return GetTile(index.I, index.J);
        }

        public Tile GetTile(Vector2 position)
        {
            return tiles[(int)position.X / GameInfo.TILE_X, (int)position.Y / GameInfo.TILE_Y];
        }

        public Tile GetTile(int i, int j)
        {
            return tiles[i, j];
        }

        // Variation on wiki implementation of Bresenham's line algorithm
        public bool IsBlockBetween(Vector2 position1, Vector2 position2)
        {
            int x0 = (int)position1.X;
            int y0 = (int)position1.Y;
            int x1 = (int)position2.X;
            int y1 = (int)position2.Y;

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);

            int sx = (x0 < x1) ? GameInfo.TILE_X : -GameInfo.TILE_X;
            int sy = (y0 < y1) ? GameInfo.TILE_Y : -GameInfo.TILE_Y;
            int err = dx - dy;

//            string t = "";
            int it = 0;
            while (true)
            {
//                t += "{ " + x0 + ", " + y0 + "}";
                
                if (it++ > 0 && IsBlockingVisionAt(new Vector2(x0, y0)))
                {
//                    Console.WriteLine("p:" + position1);
//                    Console.WriteLine("1:" + t);
                    return true;
                }

                bool end1 = false;
                if (sx > 0)
                    end1 = (x0 >= x1);   
                else
                    end1 = (x0 <= x1);

                bool end2 = false;
                if (sy > 0)
                    end2 = (y0 >= y1);
                else
                    end2 = (y0 <= y1);

                if (end1 && end2)
                    break;

                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x0 += sx;
                }

                bool end3 = false;
                if (sx > 0)
                    end3 = (x0 >= x1);
                else
                    end3 = (x0 <= x1);

                bool end4 = false;
                if (sy > 0)
                    end4 = (y0 >= y1);
                else
                    end4 = (y0 <= y1);

                if (end3 && end4)
                {
//                    Console.WriteLine("p:" + position1);
//                    Console.WriteLine("2:" + t);
                    return IsBlockingVisionAt(new Vector2(x0, y0));
                }

                if (e2 < dx)
                {
                    err += dx;
                    y0 += sy;
                }
            }
//            Console.WriteLine("p:" + position1);
//            Console.WriteLine("3:" + t);
            return false;
        }

        public Vector2 GetCollisionResolution(Vector2 point)
        {
            Vector2 outOfBoundResolution = Vector2.Zero;
            if (point.X < 0)
                outOfBoundResolution.X = point.X;
            else if (point.X >= ColumnCount * GameInfo.TILE_X)
                outOfBoundResolution.X = point.X - ColumnCount * GameInfo.TILE_X + 1;

            if (point.Y < 0)
                outOfBoundResolution.Y = point.Y;
            else if (point.Y >= RowCount * GameInfo.TILE_Y)
                outOfBoundResolution.Y = point.Y - RowCount * GameInfo.TILE_Y + 1;

            if (outOfBoundResolution != Vector2.Zero)
                return outOfBoundResolution;

            return GetTile(point).GetHitbox().GetCollisionResolution(point);
        }

        public float GetCollisionTowardsRight(BoundingBox box)
        {
            float d1 = 0;
            float d2 = 0;
            if (IsBlockAt(box.TopRight))
            {
                d1 = GetCollisionResolution(box.TopRight).X;

                if (IsBlockAt(box.TopRight + new Vector2(-GameInfo.TILE_X, 0)))
                    d1 += GameInfo.TILE_X;
            }

            if (IsBlockAt(box.BottomRight))
            {
                d2 = GetCollisionResolution(box.BottomRight).X;

                if (IsBlockAt(box.BottomRight + new Vector2(-GameInfo.TILE_X, 0)))
                    d2 += GameInfo.TILE_X;
            }

            return -MathHelper.Max(d1, d2);
        }

        public float GetCollisionTowardsLeft(BoundingBox box)
        {
            float d1 = 0;
            float d2 = 0;
            if (IsBlockAt(box.TopLeft))
            {
                d1 = -GetCollisionResolution(box.TopLeft).X;

                if (IsBlockAt(box.TopLeft + new Vector2(GameInfo.TILE_X, 0)))
                    d1 += GameInfo.TILE_X;
            }

            if (IsBlockAt(box.BottomLeft))
            {
                d2 = -GetCollisionResolution(box.BottomLeft).X;

                if (IsBlockAt(box.BottomLeft + new Vector2(GameInfo.TILE_X, 0)))
                    d2 += GameInfo.TILE_X;
            }

            return MathHelper.Max(d1, d2);
        }

        public float GetCollisionTowardsBottom(BoundingBox box)
        {
            float d1 = 0;
            float d2 = 0;
            if (IsBlockAt(box.BottomLeft))
            {
                d1 = GetCollisionResolution(box.BottomLeft).Y;

                if (IsBlockAt(box.BottomLeft + new Vector2(0, -GameInfo.TILE_Y)))
                    d1 += GameInfo.TILE_Y;
            }

            if (IsBlockAt(box.BottomRight))
            {
                d2 = GetCollisionResolution(box.BottomRight).Y;

                if (IsBlockAt(box.BottomRight + new Vector2(0, -GameInfo.TILE_Y)))
                    d2 += GameInfo.TILE_Y;
            }

            return -MathHelper.Max(d1, d2);
        }

        public float GetCollisionTowardsTop(BoundingBox box)
        {
            float d1 = 0;
            float d2 = 0;
            if (IsBlockAt(box.TopLeft))
            {
                d1 = -GetCollisionResolution(box.TopLeft).Y;

                if (IsBlockAt(box.TopLeft + new Vector2(0, GameInfo.TILE_Y)))
                    d1 += GameInfo.TILE_Y;
            }

            if (IsBlockAt(box.TopRight))
            {
                d2 = -GetCollisionResolution(box.TopRight).Y;

                if (IsBlockAt(box.TopRight + new Vector2(0, GameInfo.TILE_Y)))
                    d1 += GameInfo.TILE_Y;
            }

            return MathHelper.Max(d1, d2);
        }

        public Tile[,] GetTiles()
        {
            return tiles;
        }

        private void Init()
        {
            IsCloneable = false;
            tiles = new Tile[ColumnCount, RowCount];
            Npcs = new List<Actor>();
            IsLightingEnabled = false;
            CreateTiles();
        }

        private void CreateTiles()
        {
            for (int i = 0; i < ColumnCount; i++)
                for (int j = 0; j < RowCount; j++)
                    tiles[i, j] = new Tile(GetPositionFromTileIndex(i, j));
        }

        private Vector2 GetPositionFromTileIndex(int i, int j)
        {
            return new Vector2(i * GameInfo.TILE_X + GameInfo.TILE_X / 2, j * GameInfo.TILE_Y + GameInfo.TILE_Y / 2);
        }
    }
}

