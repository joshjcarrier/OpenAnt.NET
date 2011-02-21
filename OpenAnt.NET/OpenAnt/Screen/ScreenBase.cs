namespace OpenAnt.Screen
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Engine;

    /// <summary>
    /// Handles player logic, movement.
    /// </summary>
    public abstract class ScreenBase : IScreen
    {
        /// <summary>
        /// Gets the world manager.
        /// </summary>
        protected readonly IWorldManager WorldManager;
        
        /// <summary>
        /// The age in ticks of the previous input state.
        /// </summary>
        private int prevStateAge;

        /// <summary>
        /// The previous keyboard state.
        /// </summary>
        private KeyboardState prevState;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenBase"/> class.
        /// </summary>
        /// <param name="worldManager">
        /// The world Manager.
        /// </param>
        protected ScreenBase(IWorldManager worldManager)
        {
            // TODO register world manager switchout
            this.WorldManager = worldManager;
        }

        /// <summary>
        /// Gets InputMapping.
        /// </summary>
        protected abstract IDictionary<Keys, Action> InputMappings { get; }
        
        /// <summary>
        /// Draws graphical artifacts using the canvas.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        public abstract void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Runs engine updates.
        /// </summary>
        /// <param name="keyboardState">
        /// The keyboard State.
        /// </param>
        public virtual void Update(KeyboardState keyboardState)
        {
            var inputActionIgnored = true;

            this.InputMappings.ForEach(o => inputActionIgnored |= this.ProcessKeyboardInput(keyboardState, o.Key, o.Value));

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
        protected bool ProcessKeyboardInput(KeyboardState keyboardState, Keys key, Action inputAction)
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
