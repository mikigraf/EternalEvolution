using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace EternalEvolution
{
    class InputManager
    {
        KeyboardState currentState, previousState;

        private static InputManager instance;

        public static InputManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new InputManager();
                }
                return instance;
            }
        }

        public void Update()
        {
            previousState = currentState;
            if (!ScreenManager.Instance.isTransitioning)
            {
                currentState = Keyboard.GetState();
            }
        }

        public bool KeyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentState.IsKeyDown(key) && previousState.IsKeyUp(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool KeyReleased(params Keys[] keys)
        {
            foreach(Keys key in keys)
            {
                if(currentState.IsKeyUp(key) && previousState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool KeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (currentState.IsKeyDown(key) && previousState.IsKeyUp(key))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
