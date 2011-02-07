namespace OpenAnt.Screen
{
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Displays all in-game content.
    /// </summary>
    public class GameCanvasScreen
    {
        /// <summary>
        /// The game state machine.
        /// </summary>
        private readonly GameStateMachine stateMachine;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameCanvasScreen"/> class.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        public GameCanvasScreen(ContentProvider contentProvider)
        {
            this.stateMachine = new GameStateMachine(contentProvider);    
        }

        /// <summary>
        /// Updates the game canvas screen, with input information.
        /// </summary>
        /// <param name="keyboardState">
        /// The keyboard state.
        /// </param>
        public void Update(KeyboardState keyboardState)
        {
            // TODO determine how to route information?
            this.stateMachine.Update(keyboardState);
        }

        /// <summary>
        /// Draws the game canvas screen.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        public void Draw(SpriteBatch spriteBatch)
        {
            this.stateMachine.Draw(spriteBatch);
        }
    }
}
