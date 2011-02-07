namespace OpenAnt.Canvas
{
    #region using directives
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    #endregion

    /// <summary>
    /// An underground eagle eye world canvas.
    /// </summary>
    public class UndergroundEagleEyeWorldCanvas : EagleEyeWorldCanvas
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UndergroundEagleEyeWorldCanvas"/> class.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        /// <param name="worldBoundary">
        /// The world boundary.
        /// </param>
        public UndergroundEagleEyeWorldCanvas(ContentProvider contentProvider, Rectangle worldBoundary) : base(contentProvider, worldBoundary)
        {
        }

        /// <summary>
        /// Draws the overlay.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        public override void DrawOverlay(SpriteBatch spriteBatch)
        {
            // spriteBatch.Draw(texture, new Rectangle(0, 40 - this.Viewport.Y * 20, 800, 4), Color.Green);
        }

        /// <summary>
        /// Draws the underlay.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        public override void DrawUnderlay(SpriteBatch spriteBatch)
        {
            // spriteBatch.Draw(texture, new Rectangle(0, 40 - this.Viewport.Y * 20, 800, 260), Color.SandyBrown);
            // spriteBatch.Draw(texture, new Rectangle(0, 300 - this.Viewport.Y * 20, 800, 500), Color.RosyBrown);
        }
    }
}
