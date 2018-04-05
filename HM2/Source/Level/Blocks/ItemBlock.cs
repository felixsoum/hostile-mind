using System;

namespace HostileMind
{
    public class ItemBlock : Block
    {
        private Item.ItemType item = Item.ItemType.NONE;
        private string collectText;
        private bool isOrientationDependant = false;
        private PlayerActor.Orientation orientation;

        public ItemBlock(Sprite blockSprite, Tile occupantTile, Item.ItemType item, string collectText)
            : base(blockSprite, occupantTile)
        {
            this.item = item;
            this.collectText = collectText;
        }

        public ItemBlock(Sprite blockSprite, Tile occupantTile, Item.ItemType item, string collectText, PlayerActor.Orientation orientation)
            : base(blockSprite, occupantTile)
        {
            this.item = item;
            this.collectText = collectText;
            this.orientation = orientation;
            isOrientationDependant = true;
        }

        public ItemBlock(ItemBlock o)
            : base(o)
        {
            item = o.item;
            collectText = o.collectText;
            isOrientationDependant = o.isOrientationDependant;
            orientation = o.orientation;
        }

        public override Block Clone()
        {
            return new ItemBlock(this);
        }

        public override void OnPlayerAction(PlayerActor.Orientation orientation)
        {
            bool orientationCondition = isOrientationDependant && this.orientation != orientation;

            if (item != Item.ItemType.NONE && !orientationCondition)
            {
                PlayerItems.Add(new Item(item));
                item = Item.ItemType.NONE;
                Dialog.SetText(collectText);
                Sounds.Get("item").Play();
            }
            else
            {
                base.OnPlayerAction(orientation);
            }
        }
    }
}

