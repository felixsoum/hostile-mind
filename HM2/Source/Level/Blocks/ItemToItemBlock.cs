using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class ItemToItemBlock : ItemBlock
    {
        private Item.ItemType itemNeeded;
        private string lockedText;

        public ItemToItemBlock(Sprite blockSprite, Tile occupantTile, Item.ItemType itemNeeded, Item.ItemType item, string lockedText, string collectText)
            : base(blockSprite, occupantTile, item, collectText)
        {
            this.itemNeeded = itemNeeded;
            this.lockedText = lockedText;
        }
        public ItemToItemBlock(Sprite blockSprite, Tile occupantTile, Item.ItemType item, Item.ItemType itemNeeded, string lockedText, string collectText, PlayerActor.Orientation orientation)
            : base(blockSprite, occupantTile, item, collectText, orientation)
        {
            this.itemNeeded = itemNeeded;
            this.lockedText = lockedText;
        }

        public override void OnPlayerAction(PlayerActor.Orientation orientation)
        {
            var text = lockedText;
            if (!PlayerItems.Has(itemNeeded))
            {
                Dialog.SetText(text);
                return;
            }
            base.OnPlayerAction(orientation);
        }

    }
}
