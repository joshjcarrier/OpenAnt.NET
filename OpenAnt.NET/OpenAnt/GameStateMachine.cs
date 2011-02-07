namespace OpenAnt
{
    using System;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Engine;
    using World;

    /// <summary>
    /// Decides how to show in-game overlays and input interpretation..
    /// </summary>
    public class GameStateMachine
    {
        private GameEngine currentEngine;
        private IWorldManager worldManager;
        private int prevStateAge;
        private KeyboardState prevState;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStateMachine"/> class.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        public GameStateMachine(ContentProvider contentProvider)
        {
            // TODO we'd load a save game from here possibly
            // NOTE this is how we go between local/network
            this.worldManager = new InMemoryWorldManager(contentProvider);

            // TODO state machine flips between engines
            this.currentEngine = OverworldGameEngine.Create(contentProvider, this.worldManager);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // gameplay
            this.currentEngine.Draw(spriteBatch);
        }

        private int minorTick = 0;

        public void Update(KeyboardState keyboardState)
        {
            if (this.minorTick == 0)
            {
                this.currentEngine.Update();
            }
            
            this.minorTick += 1;
            this.minorTick %= 30;

            // TODO mouse instead, combo keys? this is also really a function of the engine, right
            var inputActionIgnored = this.ProcessKeyboardInput(keyboardState, Keys.D, () => this.currentEngine.MovePlayer(1, 0));
            inputActionIgnored |= this.ProcessKeyboardInput(keyboardState, Keys.A, () => this.currentEngine.MovePlayer(-1, 0));
            inputActionIgnored |= this.ProcessKeyboardInput(keyboardState, Keys.W, () => this.currentEngine.MovePlayer(0, -1));
            inputActionIgnored |= this.ProcessKeyboardInput(keyboardState, Keys.S, () => this.currentEngine.MovePlayer(0, 1));
            inputActionIgnored |= this.ProcessKeyboardInput(keyboardState, Keys.Space, () => this.currentEngine.Interact());
            
            if(inputActionIgnored)
            {
                prevStateAge += 1;
            }

            // click'n'hold
            if (prevStateAge > 20)
            {
                prevState = new KeyboardState();
                prevStateAge = 0;
            }
            else
            {
                prevState = keyboardState;   
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyboardState"></param>
        /// <param name="key"></param>
        /// <param name="inputAction"></param>
        /// <returns>
        /// True if the keyboard input event was ignored.
        /// </returns>
        private bool ProcessKeyboardInput(KeyboardState keyboardState, Keys key, Action inputAction)
        {
            if (!keyboardState.IsKeyDown(key)) 
            {
                return false;
            }

            if (this.prevState.IsKeyDown(key))
            {
                return true;
            }
            
            inputAction();
            this.prevStateAge = 0;
            return false;
        }
    }
}
