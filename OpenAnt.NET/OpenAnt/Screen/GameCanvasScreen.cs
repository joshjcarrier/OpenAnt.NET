namespace OpenAnt.Screen
{
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Displays all in-game content.
    /// </summary>
    public class GameCanvasScreen
    {
        private GameStateMachine stateMachine;

        // TODO replace with content loader
        public GameCanvasScreen(ContentProvider contentProvider)
        {
            stateMachine = new GameStateMachine(contentProvider);    
        }

        public void Update(KeyboardState keyboardState)
        {
            // TODO determine how to route information?
            stateMachine.Update(keyboardState);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            stateMachine.Draw(spriteBatch);
        }
    }
}
