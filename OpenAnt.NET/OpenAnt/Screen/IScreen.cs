namespace OpenAnt.Screen
{
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Represents a screen, which can accept draw requests and performs updates.
    /// </summary>
    public interface IScreen
    {
        /// <summary>
        /// Draws graphical artifacts using the canvas.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Performs an update on the screen.
        /// </summary>
        /// <param name="keyboardState">
        /// The keyboard state.
        /// </param>
        void Update(KeyboardState keyboardState);
    }
}