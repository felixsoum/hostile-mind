using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostileMind
{
    class PushableItemBlock : PushableBlock
    {
        private string text;
        private Item.ItemType itemNeeded;

        public PushableItemBlock(Tile occupiedTile, Sprite sprite, Item.ItemType itemNeeded, string text)
            : base (occupiedTile, sprite)
        {
            this.itemNeeded = itemNeeded;
            this.text = text;
        }

        public override void OnPlayerAction(PlayerActor.Orientation orientation)
        {
            var text2 = text;
            if (!PlayerItems.Has(itemNeeded))
            {
                Dialog.SetText(text2);
                return;
            }
            else
            {
                base.OnPlayerAction(orientation);
            }
        }
    }
}
