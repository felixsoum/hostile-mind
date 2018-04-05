using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace HostileMind
{
    public static class Textures
    {
        public static ContentManager Content { private get; set; }
        private static IDictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        private const string TEXTURE_FOLDER = @"Textures\";

        public static void Load(string name)
        {
            if (textures.ContainsKey(name))
                return;

            Texture2D texture = Content.Load<Texture2D>(TEXTURE_FOLDER + name);
            textures.Add(name, texture);
        }

        public static Texture2D Get(string name)
        {
            Texture2D texture;
            if (textures.TryGetValue(name, out texture))
                return texture;

            return null;
        }
    }
}

