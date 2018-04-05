using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace HostileMind
{
    public static class PlayerItems
    {
        private static List<Item> items = new List<Item>();
        private const int INITIAL_OFFSET_X = 32;
        private const int INITIAL_OFFSET_Y = 32;
        private static Vector2 offset;
        private const int SPACE_BETWEEN_ITEMS = 64;

        static PlayerItems()
        {
            offset = new Vector2(40, GameInfo.SCREEN_BAR_LENGTH / 2);
        }

        public static List<Item> Get()
        {
            var clone = new List<Item>();
            foreach (var i in items)
                clone.Add(new Item(i));
            return clone;
        }

        public static void Set(List<Item> it)
        {
            items = it;
        }

        public static void Add(Item item)
        {
            items.Add(item);
        }

        public static void Remove(Item.ItemType type)
        {
            items.RemoveAll((x => x.Type == type));
        }

        //new
        public static void RemoveOne(Item.ItemType type)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Type == type)
                {
                    items.Remove(items[i]);
                    return;
                }
            }
        }

        public static void Clear()
        {
            items.Clear();
        }

        public static bool Has(Item.ItemType type)
        {
            return items.Any((x => x.Type == type));
        }

        public static void Update()
        {
            foreach (var item in items)
                item.Update();
        }

        public static void Draw()
        {

            for (int i = 0; i < items.Count; i++)
            {
                items[i].DrawToInventory(new Vector2(i *SPACE_BETWEEN_ITEMS, 0) + offset);
            }
        }
    }
}

