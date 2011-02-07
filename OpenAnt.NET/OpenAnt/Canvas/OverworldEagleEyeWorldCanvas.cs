namespace OpenAnt.Canvas
{
    #region using directives
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;

    #endregion

    /// <summary>
    /// The overworld eagle-eye world canvas.
    /// </summary>
    public class OverworldEagleEyeWorldCanvas : EagleEyeWorldCanvas
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OverworldEagleEyeWorldCanvas"/> class.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        /// <param name="worldBoundary">
        /// The world Boundary.
        /// </param>
        public OverworldEagleEyeWorldCanvas(ContentProvider contentProvider, Rectangle worldBoundary)
            : base(contentProvider, worldBoundary)
        {
        }

        /// <summary>
        /// Draws any overlay artifacts after sprites and underlay have been drawn.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        public override void DrawOverlay(SpriteBatch spriteBatch)
        {
            // TODO drawing something meaningful
            // spriteBatch.Draw(contentProvider.GetSpriteTexture(SpriteResource.Seed1), new Rectangle(0,0,50,50), Color.White);
            spriteBatch.Draw(this.contentProvider.GetTerrainTexture(null), new Rectangle(0, 0, 100, 800), Color.Silver);
        }

        /// <summary>
        /// Renders the underlay, before world sprites or the overlay placed on top.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        public override void DrawUnderlay(SpriteBatch spriteBatch)
        {
            // TODO
        }
    }
}
