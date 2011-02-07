using System;

namespace OpenAnt.Canvas
{
    #region using directives
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Entity;

    #endregion

    /// <summary>
    /// Renders world data with an eagle-eye perspective.
    /// </summary>
    public abstract class EagleEyeWorldCanvas
    {
        protected ContentProvider contentProvider;
        protected Texture2D texture;
        protected Rectangle worldBoundary;
        private readonly string buildstamp = DateTime.Today.ToString("yyyyMMdd");

        /// <summary>
        /// Initializes a new instance of the <see cref="EagleEyeWorldCanvas"/> class.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        public EagleEyeWorldCanvas(ContentProvider contentProvider, Rectangle worldBoundary)
        {
            // NOTE content provider to build overlay textures...
            this.contentProvider = contentProvider;
            this.texture = contentProvider.GetTerrainTexture(TerrainResource.Foliage1);
            this.Viewport = new Rectangle(0, 0, 30, 30);
            this.worldBoundary = worldBoundary;
        }

        public Rectangle Viewport;

        /// <summary>
        /// Draws any overlay artifacts after sprites and underlay have been drawn.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        public abstract void DrawOverlay(SpriteBatch spriteBatch);

        /// <summary>
        /// Renders sprites in the world for this eage-eye perspective. Should be drawn after underlay.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        /// <param name="spriteData">
        /// The sprite data.
        /// </param>
        public void DrawSprites(SpriteBatch spriteBatch, IEnumerable<GameEntityBase> spriteData)
        {
            spriteBatch.DrawString(this.contentProvider.GetFont(FontResource.SegoeUiMonoRegular), "OpenAnt.NET build " + buildstamp, new Vector2(5, 5), Color.White); 

            // TODO viewport restriction optimization);)
            foreach (var sprite in spriteData)
            {
                var viewportPosition = sprite.Position.Location;
                viewportPosition.X -= this.Viewport.Left;
                viewportPosition.Y -= this.Viewport.Top;
                sprite.Render(spriteBatch, viewportPosition);    
            }
        }

        /// <summary>
        /// Renders the underlay, before world sprites or the overlay placed on top.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        public abstract void DrawUnderlay(SpriteBatch spriteBatch);

        /// <summary>
        /// Centralizes the viewport on the given position.
        /// </summary>
        /// <param name="centerX">
        /// The center x.
        /// </param>
        /// <param name="centerY">
        /// The center y.
        /// </param>
        public void CentralizeViewport(int centerX, int centerY)
        {
            var viewportX = centerX - 20;
            var viewportY = centerY - 10;

            if (viewportX < 0)
            {
                viewportX = 0;
            }

            if (viewportY < 0)
            {
                viewportY = 0;
            }

            // TODO what's the formula for this...
            if (viewportX > this.worldBoundary.Width - 35)
            {
                viewportX = this.worldBoundary.Width - 35;
            }

            if (viewportY > this.worldBoundary.Height - 24)
            {
                viewportY = this.worldBoundary.Height - 24;
            }

            this.Viewport.Location = new Point(viewportX, viewportY);
        }
    }    
}
