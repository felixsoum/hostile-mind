using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace HostileMind
{
    public static class Sounds
    {
        public static ContentManager Content { private get; set; }
        private static IDictionary<string, SoundEffect> textures = new Dictionary<string, SoundEffect>();
        private const string SOUND_FOLDER = @"Sounds\";

        public static void Load(string name)
        {
            if (textures.ContainsKey(name))
                return;

            SoundEffect texture = Content.Load<SoundEffect>(SOUND_FOLDER + name);
            textures.Add(name, texture);
        }

        public static SoundEffect Get(string name)
        {
            SoundEffect texture;
            if (textures.TryGetValue(name, out texture))
                return texture;

            return null;
        }
    }
}

