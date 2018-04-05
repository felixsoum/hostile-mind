using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HostileMind
{
    public class Item
    {

        // This order respects the item sequence on the spritesheet
        public enum ItemType
        {
            NONE = -1,
            BANDAGE,
            PILL,
            TOWEL,
            ALCOHOL,
            AXE,
            GLOVES,
            KEY,
            MEDKIT,
            BUCKET,
            SMELLINGSALT,
            PHONE,
            BLUE_KEY,
            RED_KEY,
            GREEN_KEY,
            PURPLE_KEY,
            CROWBAR,
            FLASHLIGHT,
            POLE,
            BOLTCUTTERS,
            KEYCARD,
            SWITCH, //
            EXTINGUISHER,
            BOTTLE
        }

        public ItemType Type { get; private set; }
        private Sprite sprite;
        private Color VERY_DARK_GRAY = new Color(32, 32, 32);

        public Item(ItemType type)
        {
            Type = type;

            // Make sure the column and row count is correct when updating the spritesheet
            Texture2D texture = Textures.Get("items");
            int row = texture.Height / 48;
            int col = texture.Width / 48;
            sprite = new Sprite(texture, col, row);
            sprite.SetFrame((int)type);
        }

        public Item(Item o)
        {
            Type = o.Type;
            sprite = new Sprite(o.sprite);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void DrawToFloor(Vector2 position)
        {
            sprite.Draw(position, Depth.FLOOR_ITEM);
        }

        public void DrawToFloor(Vector2 position, float depth)
        {
            sprite.Draw(position, depth);
        }

        public void DrawToInventory(Vector2 position)
        {
            Rectangle outerBounds = new Rectangle((int)position.X - sprite.GetFrameWidth()/2,
                                             (int)position.Y - sprite.GetFrameHeight()/2,
                                             sprite.GetFrameWidth(),
                                             sprite.GetFrameHeight());

            Rectangle innerBounds = outerBounds;
            innerBounds.X += 2;
            innerBounds.Y += 2;
            innerBounds.Width -= 4;
            innerBounds.Height -= 4;

            // Add float values to depth to preserve the correct order
            Renderer.DrawRectangle(outerBounds, Color.Gray, Depth.INVENTORY + 0.2f);
            Renderer.DrawRectangle(innerBounds, VERY_DARK_GRAY, Depth.INVENTORY + 0.1f);
            sprite.Draw(position, Depth.INVENTORY);
        }

        public int GetFrameHeight()
        {
            return sprite.GetFrameHeight();
        }
    }
}

