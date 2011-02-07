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
        private int currentEngine;
        private GameEngine[] engines;
        // private IWorldManager worldManager;
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
            // TODO these should really be the same world managers?
            // NOTE this is how we go between local/network
            var overWorldManager = new InMemoryWorldManager(contentProvider);
            var underWorldManager = new InMemoryWorldManager(contentProvider);

            // TODO state machine flips between engines
            engines = new GameEngine[2];
            engines[0] = OverworldGameEngine.Create(contentProvider, overWorldManager);
            engines[1] = UndergroundGameEngine.Create(contentProvider, underWorldManager);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // gameplay
            this.engines[this.currentEngine].Draw(spriteBatch);
        }

        private int minorTick = 0;

        public void Update(KeyboardState keyboardState)
        {
            if (this.minorTick == 0)
            {
                this.engines.ForEach(o => o.Update());
            }
            
            this.minorTick += 1;
            this.minorTick %= 30;

            // TODO mouse instead, combo keys? this is also really a function of the engine, right
            var inputActionIgnored = this.ProcessKeyboardInput(keyboardState, Keys.D, () => this.engines[this.currentEngine].MovePlayer(1, 0));
            inputActionIgnored |= this.ProcessKeyboardInput(keyboardState, Keys.A, () => this.engines[this.currentEngine].MovePlayer(-1, 0));
            inputActionIgnored |= this.ProcessKeyboardInput(keyboardState, Keys.W, () => this.engines[this.currentEngine].MovePlayer(0, -1));
            inputActionIgnored |= this.ProcessKeyboardInput(keyboardState, Keys.S, () => this.engines[this.currentEngine].MovePlayer(0, 1));
            inputActionIgnored |= this.ProcessKeyboardInput(keyboardState, Keys.Space, () => this.engines[this.currentEngine].Interact());

            // TODO temporary, until engines can signal a switch-out
            inputActionIgnored |= this.ProcessKeyboardInput(keyboardState, Keys.Q, () => { this.currentEngine += 1; this.currentEngine %= 2; }); 
            
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
