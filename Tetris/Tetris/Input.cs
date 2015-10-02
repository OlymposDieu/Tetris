using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Tetris
{
    class Input
    {
        KeyboardState previousKeyboard;
        MouseState previousMouse;

        IList<Keys> pressedKeys;

        public Input()
        {
            pressedKeys = new List<Keys>();
        }

        public void Update()
        {
            previousKeyboard = Keyboard.GetState();
            previousMouse = Mouse.GetState();
        }
        
        public void UpdateKeys()
        {
            foreach (Keys key in Keyboard.GetState().GetPressedKeys())
                if (!pressedKeys.Contains(key))
                    pressedKeys.Add(key);
        }

        public bool WasPressed(Keys key)
        {
            return pressedKeys.Contains(key);
        }

        public void Clear()
        {
            pressedKeys.Clear();
        }
    }
}