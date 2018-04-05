using System;

namespace HostileMind
{
    public class ItemCollectOnStep : OnStepCommand
    {
        private ItemTile tile;

        public ItemCollectOnStep(ItemTile tile)
        {
            this.tile = tile;
            tile.PushableLockCount++;
        }

        public void OnStep()
        {
            if (tile.IsItemCollected)
                return;

            Sounds.Get("item").Play();
            tile.PushableLockCount--;
            tile.IsItemCollected = true;
            PlayerItems.Add(tile.CollectableItem);
            Dialog.SetText("You acquired the " + tile.CollectableItem.Type + " item.");
            tile.CollectableItem = null;
        }

        public OnStepCommand Clone()
        {
            var clone = new ItemCollectOnStep(new ItemTile(tile));
            return clone;
        }
    }
}

