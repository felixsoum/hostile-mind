using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class Block
    {
		public enum BlockMessage
		{
			REMOVE
		}

        public Vector2 Position { get; set; }
        public Tile OccuppiedTile { get; set; }
        private Sprite sprite;
        private Vector2 offset = Vector2.Zero;
        private const string NOTHING_TEXT = "Nothing interesting to see here.";
        public bool IsShadowing { get; set; }

        public Block(Tile occupiedTile)
        {
            sprite = null;
            Position = occupiedTile.Position;
            OccuppiedTile = occupiedTile;
            offset = Vector2.Zero;
            IsShadowing = false;
        }

        public Block(Sprite sprite, Tile occupiedTile)
        {
            this.sprite = sprite;
            Position = occupiedTile.Position;
            OccuppiedTile = occupiedTile;
            offset = new Vector2(sprite.GetFrameWidth() / 2 - GameInfo.TILE_X / 2, -sprite.GetFrameHeight() / 2 + GameInfo.TILE_Y / 2);
            IsShadowing = false;
        }

        public Block(Block block)
        {
            Position = block.Position;
            if (block.sprite != null)
                sprite = new Sprite(block.sprite);
            offset = block.offset;
            IsShadowing = block.IsShadowing;
        }

        public virtual Block Clone()
        {
            return new Block(this);
        }

        public virtual void Update()
        {
            if (sprite != null)
                sprite.Update();
        }

        public virtual void Draw()
        {
			Draw(Color.White);
        }

		public virtual void Draw(Color color)
		{
			if (sprite != null)
				sprite.Draw(Position + offset, color, Depth.GetDepthFromY(Position.Y));
		}

        public virtual void OnPlayerAction(PlayerActor.Orientation orientation)
        {
            Dialog.SetText(NOTHING_TEXT);
        }

		public virtual void OnMessage(BlockMessage m)
		{
			switch (m)
			{
				case BlockMessage.REMOVE:
					OccuppiedTile.OccupantBlock = null;
					break;
			}
		}
    }
}

