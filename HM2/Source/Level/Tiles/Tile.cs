using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HostileMind
{
    public class Tile
    {
        public Vector2 Position { get; set; }
        public bool IsBlocked
        {
            get { return Floor == NullSprite.Instance || OccupantBlock != null; }

        }
        public Block OccupantBlock { get; set; }
        public Sprite Floor { get; set; }
        private Sprite wall = NullSprite.Instance;
        private Vector2 wallOffset = Vector2.Zero;
        private Vector2 blockOffset = Vector2.Zero;
        private List<OnStepCommand> onStepCommands = new List<OnStepCommand>();
        private Color highlightColor;
        private bool isHighlighted = false;

        // Pushability is whether a block can be pushed to this tile or not
        // It does not impact the player's ability to walk on the tile
        public bool IsPushableTo { get { return !IsBlocked && PushableLockCount == 0; } }
        public int PushableLockCount { get; set; }

        public Lighting Light { get; set; }

        public Tile(Vector2 position)
            : this(NullSprite.Instance, position)
        {
        }

        public Tile(Sprite floor, Vector2 position)
        {
            this.Floor = floor;
            Position = position;
            OccupantBlock = null;
            PushableLockCount = 0;
            Light = new Lighting();
        }

        public Tile(Sprite floor, Sprite block, Vector2 position)
            : this(floor, position)
        {
            blockOffset = new Vector2(0, -block.GetFrameHeight() / 2 + GameInfo.TILE_Y / 2);
            OccupantBlock = new Block(block, this);
        }

        public Tile(Tile tile)
        {
            Position = tile.Position;
            if (tile.OccupantBlock != null)
                OccupantBlock = tile.OccupantBlock.Clone();
            if (OccupantBlock != null)
                OccupantBlock.OccuppiedTile = this;
            Floor = tile.Floor;
            wall = tile.wall;
            wallOffset = tile.wallOffset;
            blockOffset = tile.blockOffset;
//            foreach (var c in tile.onStepCommands)
//                onStepCommands.Add(c.Clone());
            onStepCommands = tile.onStepCommands;
            highlightColor = tile.highlightColor;
            isHighlighted = tile.isHighlighted;
            Light = tile.Light;
        }

        public virtual Tile Clone()
        {
            return new Tile(this);
        }

        public virtual void Update()
        {
            wall.Update();
            Floor.Update();

            if (OccupantBlock != null)
                OccupantBlock.Update();
        }

        public virtual void Draw()
        {
            // Use a dark color to shadow the wall and floor if there is a door
            var lightColor = Light.ToColor();
            if (OccupantBlock != null && OccupantBlock.IsShadowing)
                lightColor = new Color(50, 50, 50);

            wall.Draw(Position + wallOffset, lightColor, Depth.GetDepthFromY(Position.Y - GameInfo.TILE_Y / 2));
            Floor.Draw(Position + blockOffset, lightColor, Depth.FLOOR);

            if (OccupantBlock != null)
                OccupantBlock.Draw(Light.ToColor());

            if (isHighlighted)
                Renderer.spriteBatch.Draw(Renderer.White, GetHighlightRectangle(), null, highlightColor, 0, Vector2.Zero, SpriteEffects.None, Depth.FLOOR_HIGHLIGHT);
        }

        public BoundingBox GetHitbox()
        {
            return new BoundingBox(Position.X - GameInfo.TILE_X / 2,
                                   Position.Y - GameInfo.TILE_Y / 2,
                                   Position.X + GameInfo.TILE_X / 2 - 1,
                                   Position.Y + GameInfo.TILE_Y / 2 - 1);
        }

        public Rectangle GetHighlightRectangle()
        {
            return new Rectangle((int)Position.X - GameInfo.TILE_X / 2,
                                 (int)Position.Y - GameInfo.TILE_Y / 2,
                                 GameInfo.TILE_X,
                                 GameInfo.TILE_Y);
        }

		public void AddWall(Sprite sprite)
		{
			wall = sprite;
			wallOffset = new Vector2(0, -wall.GetFrameHeight() / 2 - GameInfo.TILE_Y / 2);
		}

        public void AddHighlight(Color color)
        {
            isHighlighted = true;
            highlightColor = color;
        }

        public virtual void OnStep()
        {
            foreach (var command in onStepCommands)
                command.OnStep();
        }

        public void AddOnStepCommand(OnStepCommand command)
        {
            onStepCommands.Add(command);
        }

        public void ClearOnStepCommand()
        {
            onStepCommands.Clear();
        }

        public void ClearFloor()
        {
            if (!ContainsStepCommands())
                Floor = NullSprite.Instance;
        }

        public void ClearWall()
        {
            wall = NullSprite.Instance;
        }

		public void OnMessage(Block.BlockMessage m)
		{
			if (OccupantBlock != null)
				OccupantBlock.OnMessage(m);
		}

        private bool ContainsStepCommands()
        {
            return onStepCommands.Count > 0;
        }
    }
}

