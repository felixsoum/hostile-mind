using System;

namespace HostileMind
{
    public static class BlockFactory
    {
        public static Block Create(Tile occupantTile, string inspectionText, Sprite blockSprite)
        {
            if (inspectionText == "")
                return new Block(blockSprite, occupantTile);
            else
                return new InspectableBlock(inspectionText, blockSprite, occupantTile);
        }

        public static Block Create(Tile occupantTile, string inspectionText)
        {
            if (inspectionText == "")
                return new Block(occupantTile);
            else
                return new InspectableBlock(inspectionText, occupantTile);
        }

        public static Block Create(Tile occupantTile, Sprite blockSprite, Item.ItemType item, string collectText)
        {
            return new ItemBlock(blockSprite, occupantTile, item, collectText);
        }

        public static Block Create(Tile occupantTile, Sprite blockSprite, Item.ItemType item, string collectText, PlayerActor.Orientation orientation)
        {
            return new ItemBlock(blockSprite, occupantTile, item, collectText, orientation);
        }

        public static Block Create(Tile occupantTile, Sprite blockSprite, Item.ItemType item, Item.ItemType itemNeeded, string lockedText, string collectText)
        {
            return new ItemToItemBlock(blockSprite, occupantTile, item, itemNeeded, lockedText, collectText);
        }

        public static Block Create(Tile occupantTile, Sprite blockSprite, Item.ItemType item, Item.ItemType itemNeeded, string lockedText, string collectText, PlayerActor.Orientation orientation)
        {
            return new ItemToItemBlock(blockSprite, occupantTile, item, itemNeeded, collectText, lockedText, orientation);
        }

        public static Block Create(Tile occupantTile, Sprite blockSprite, Dialog.ChoiceDelegate choiceDelegate,
                                   string choice1, string choice2)
        {
            return new ChoiceBlock(blockSprite, occupantTile, choiceDelegate, choice1, choice2);
        }

        public static Block Create(Tile occupantTile, Sprite blockSprite, Dialog.ChoiceDelegate choiceDelegate,
                                   string choice1, string choice2, string choice3)
        {
            return new ChoiceBlock(blockSprite, occupantTile, choiceDelegate, choice1, choice2, choice3);
        }

        public static Block CreatePushable(Tile occupantTile, String textureName)
        {
            return new PushableBlock(occupantTile, new Sprite(Textures.Get(textureName)));
        }
        public static Block CreatePushableItem(Tile occupantTile, String textureName, Item.ItemType itemNeeded, string text)
        {
            return new PushableItemBlock(occupantTile, new Sprite(Textures.Get(textureName)),itemNeeded, text);
        }
    }
}

