using OpenAnt.Canvas;

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
        /// <summary>
        /// Available game engines.
        /// </summary>
        private readonly GameEngine[] engines;

        /// <summary>
        /// The current game engine.
        /// </summary>
        private int currentEngine;

        /// <summary>
        /// The current minor tick value.
        /// </summary>
        private int minorTick;

        /// <summary>
        /// The age in ticks of the previous input state.
        /// </summary>
        private int prevStateAge;

        /// <summary>
        /// The previous keyboard state.
        /// </summary>
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
            // TODO subscribe to engine change events
            this.engines = new GameEngine[2];
            this.engines[0] = OverworldGameEngine.Create(contentProvider, overWorldManager);
            this.engines[1] = UndergroundGameEngine.Create(contentProvider, underWorldManager);
        }

        /// <summary>
        /// Draws for current state engine.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // gameplay
            spriteBatch.Begin();
            ViewportHelper.CurrentDevice.Viewport = ViewportHelper.SpriteViewport;
            this.engines[this.currentEngine].Draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin();
            ViewportHelper.CurrentDevice.Viewport = ViewportHelper.MenuViewport;
            this.DrawMenuOverlay(spriteBatch);
            spriteBatch.End();
        }

        /// <summary>
        /// Update the engines and process input.
        /// </summary>
        /// <param name="keyboardState">
        /// The keyboard state.
        /// </param>
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

            if (inputActionIgnored)
            {
                this.prevStateAge += 1;
            }

            // click'n'hold
            if (this.prevStateAge > 20)
            {
                this.prevState = new KeyboardState();
                this.prevStateAge = 0;
            }
            else
            {
                this.prevState = keyboardState;   
            }
        }

                /// <summary>
        /// Draw the menu overlay.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        private void DrawMenuOverlay(SpriteBatch spriteBatch)
        {
            // spriteBatch.Draw(this.contentProvider.GetTerrainTexture(null), new Rectangle(0, 0, 100, 800), Color.Silver);
        }

        /// <summary>
        /// Helps to process keyboard input.
        /// </summary>
        /// <param name="keyboardState">
        /// The keyboard state to process.
        /// </param>
        /// <param name="key">
        /// The key to process for.
        /// </param>
        /// <param name="inputAction">
        /// The action to perform when keyboard input detected.
        /// </param>
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
