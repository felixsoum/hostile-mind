using System;
using Microsoft.Xna.Framework.Input;

namespace HostileMind
{
    public static class Inputs
    {
        public static KeyboardState CurrentKeyboard { get; set; }
        public static KeyboardState PreviousKeyboard { get; set; }

        public static bool IsDown(Keys key)
        {
            return CurrentKeyboard.IsKeyDown(key);
        }

        public static bool IsUp(Keys key)
        {
            return CurrentKeyboard.IsKeyUp(key);
        }

        public static bool IsPressed(Keys key)
        {
            return CurrentKeyboard.IsKeyDown(key)
                && PreviousKeyboard.IsKeyUp(key);
        }
    }
}

