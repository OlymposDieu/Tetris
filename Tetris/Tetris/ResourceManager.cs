using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    static class ResourceManager
    {
        static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        static Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();
        static Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>();

        public static void AddTexture(string name, Texture2D texture)
        {
            if (!textures.ContainsKey(name))
                textures.Add(name, texture);
            else
                textures[name] = texture;
        }

        public static Texture2D GetTexture(string name)
        {
            return textures[name];
        }

        public static void AddFont(string name, SpriteFont font)
        {
            if (!fonts.ContainsKey(name))
                fonts.Add(name, font);
            else
                fonts[name] = font;
        }

        public static SpriteFont GetFont(string name)
        {
            return fonts[name];
        }

        public static void AddSound(string name, SoundEffect sound)
        {
            if (!sounds.ContainsKey(name))
                sounds.Add(name, sound);
            else
                sounds[name] = sound;
        }

        public static SoundEffect GetSound(string name)
        {
            return sounds[name];
        }
    }
}