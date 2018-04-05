using System;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public class DoorBlock : Block
    {
        private bool isUnlockable;
        private Item.ItemType keyItem = Item.ItemType.NONE;
        private bool isOpen = false;
        private string lockedText;
        private Block connectedBlock = null;

        public DoorBlock(Sprite sprite, Tile occupiedTile, string lockedText = "", bool isUnlockable = true)
            : base(sprite, occupiedTile)
        {
            this.isUnlockable = isUnlockable;
            this.lockedText = lockedText;
            IsShadowing = true;
        }

        public DoorBlock(Sprite sprite, Tile occupiedTile, string lockedText, Item.ItemType keyItem)
            : this(sprite, occupiedTile, lockedText, true)
        {
            this.keyItem = keyItem;
        }

        public override void OnPlayerAction(PlayerActor.Orientation orientation)
        {
            if (isOpen)
                return;

            var text = lockedText;
            bool isOpenable = false;

            if (isUnlockable)
            {
                if (keyItem == Item.ItemType.NONE)
                {
                    text = "This door is not locked.";
                    isOpenable = true;
                }
                else if (PlayerItems.Has(keyItem))
                {
                    text = "You used the " + keyItem + " to open the door.";
                    isOpenable = true;
                }
            }

            if (isOpenable)
                Open();
            else
                Sounds.Get("wood-smack").Play();

            Dialog.SetText(text);
        }

        public void Connect(Block block)
        {
            connectedBlock = block;
        }

        private void Open()
        {
            Sounds.Get("door-open").Play();
            OccuppiedTile.OccupantBlock = null;
            if (connectedBlock != null)
                connectedBlock.OnMessage(BlockMessage.REMOVE);
        }
    }
}

