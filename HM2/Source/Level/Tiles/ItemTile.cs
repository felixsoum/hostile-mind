using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HostileMind
{
    public class ItemTile : Tile
    {
        public bool IsItemCollected { get; set; }
        public Item CollectableItem { get; set; }
        private Vector2 itemOffset = Vector2.Zero;

        public ItemTile(Item.ItemType itemType, Sprite floor, Vector2 position)
            : base(new Sprite(floor), position)
        {
            CollectableItem = new Item(itemType);
            itemOffset = new Vector2(0, -CollectableItem.GetFrameHeight() / 2 + GameInfo.TILE_Y / 2);
            IsItemCollected = false;
            AddOnStepCommand(new ItemCollectOnStep(this));
        }

        public ItemTile(Tile tile, Item.ItemType itemType)
            : base(tile)
        {
            CollectableItem = new Item(itemType);
            itemOffset = new Vector2(0, -CollectableItem.GetFrameHeight() / 2 + GameInfo.TILE_Y / 2);
            IsItemCollected = false;
            AddOnStepCommand(new ItemCollectOnStep(this));
        }

        public ItemTile(ItemTile o)
            : base(o)
        {
            IsItemCollected = o.IsItemCollected;
            CollectableItem = new Item(o.CollectableItem);
            itemOffset = o.itemOffset;
        }

        public override Tile Clone()
        {
            return new ItemTile(this);
        }

        public override void Update()
        {
            if (!IsItemCollected)
                CollectableItem.Update();
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            if (!IsItemCollected)
                CollectableItem.DrawToFloor(Position + itemOffset, Depth.GetDepthFromY(Position.Y));
        }
    }
}

