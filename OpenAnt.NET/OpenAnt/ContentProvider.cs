namespace OpenAnt
{
    #region using directives

    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// Provides content.
    /// </summary>
    public class ContentProvider
    {
        /// <summary>
        /// The font cache.
        /// </summary>
        private readonly IDictionary<string, SpriteFont> fontContent;

        /// <summary>
        /// The texture cache.
        /// </summary>
        private readonly IDictionary<string, Texture2D> textureContent;

        /// <summary>
        /// The null texture.
        /// </summary>
        private readonly Texture2D nullTexture;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentProvider"/> class.
        /// </summary>
        /// <param name="contentManager">
        /// The content manager.
        /// </param>
        /// <param name="nullTexture">
        /// The null texture.
        /// </param>
        public ContentProvider(ContentManager contentManager, Texture2D nullTexture)
        {
            this.fontContent = new Dictionary<string, SpriteFont>();
            this.LoadFont(contentManager, HardCodes.FontContent, FontResource.SegoeUiMonoRegular);

            this.textureContent = new Dictionary<string, Texture2D>();
            this.nullTexture = nullTexture;

            this.LoadTexture(contentManager, HardCodes.TerrainContent, TerrainResource.Rock1);
            this.LoadTexture(contentManager, HardCodes.TerrainContent, TerrainResource.Rock2);
            this.LoadTexture(contentManager, HardCodes.TerrainContent, TerrainResource.Rock3);
            this.LoadTexture(contentManager, HardCodes.TerrainContent, TerrainResource.Foliage1);
            this.LoadTexture(contentManager, HardCodes.TerrainContent, TerrainResource.Foliage2);
            this.LoadTexture(contentManager, HardCodes.TerrainContent, TerrainResource.Foliage3);
            this.LoadTexture(contentManager, HardCodes.TerrainContent, TerrainResource.Ground1);
            this.LoadTexture(contentManager, HardCodes.TerrainContent, TerrainResource.Ground2);
            this.LoadTexture(contentManager, HardCodes.TerrainContent, TerrainResource.Ground3);
            this.LoadTexture(contentManager, HardCodes.TerrainContent, TerrainResource.Ground4);
            this.LoadTexture(contentManager, HardCodes.TerrainContent, TerrainResource.GroundRock4);

            this.LoadTexture(contentManager, HardCodes.SpriteContent, SpriteResource.YellowAntWalk1);
            this.LoadTexture(contentManager, HardCodes.SpriteContent, SpriteResource.YellowAntWalk2);

            this.LoadTexture(contentManager, HardCodes.SpriteContent, SpriteResource.Seed1);
            this.LoadTexture(contentManager, HardCodes.SpriteContent, SpriteResource.Seed2);
            this.LoadTexture(contentManager, HardCodes.SpriteContent, SpriteResource.Food1);
            this.LoadTexture(contentManager, HardCodes.SpriteContent, SpriteResource.Food2);
            this.LoadTexture(contentManager, HardCodes.SpriteContent, SpriteResource.Food3);
            this.LoadTexture(contentManager, HardCodes.SpriteContent, SpriteResource.Food4);
        }

        /// <summary>
        /// Gets a pre-loaded font.
        /// </summary>
        /// <param name="fontId">
        /// The font id.
        /// </param>
        /// <returns>
        /// The requested font, or null if not found.
        /// </returns>
        public SpriteFont GetFont(string fontId)
        {
            SpriteFont loadedFont;
            if (!this.fontContent.TryGetValue(HardCodes.FontContent + fontId, out loadedFont))
            {
                return null;
            }

            return loadedFont;
        }

        /// <summary>
        /// Gets a pre-loaded sprite texture.
        /// </summary>
        /// <param name="spriteTextureId">
        /// The sprite texture id.
        /// </param>
        /// <returns>
        /// A sprite texture, or null texture if not loaded.
        /// </returns>
        public Texture2D GetSpriteTexture(string spriteTextureId)
        {
            return this.GetTexture(HardCodes.SpriteContent + spriteTextureId);
        }

        /// <summary>
        /// Gets a pre-loaded terrain texture.
        /// </summary>
        /// <param name="terrainTextureId">
        /// The terrain texture id.
        /// </param>
        /// <returns>
        /// A terrain texture, or null texture if not loaded.
        /// </returns>
        public Texture2D GetTerrainTexture(string terrainTextureId)
        {
            return this.GetTexture(HardCodes.TerrainContent + terrainTextureId);
        }

        /// <summary>
        /// Gets a pre-loaded texture.
        /// </summary>
        /// <param name="textureId">
        /// The texture id.
        /// </param>
        /// <returns>
        /// The texture requested, or null texture if not loaded.
        /// </returns>
        private Texture2D GetTexture(string textureId)
        {
            Texture2D texture;
            if (!this.textureContent.TryGetValue(textureId, out texture))
            {
                return this.nullTexture;
            }

            return texture;
        }

        /// <summary>
        /// Loads texture.
        /// </summary>
        /// <param name="contentManager">
        /// The content manager.
        /// </param>
        /// <param name="texturePath">
        /// The texture content.
        /// </param>
        /// <param name="textureId">
        /// The texture id.
        /// </param>
        private void LoadTexture(ContentManager contentManager, string texturePath, string textureId)
        {
            this.textureContent[texturePath + textureId] = contentManager.Load<Texture2D>(texturePath + textureId);
        }

        /// <summary>
        /// Loads fonts.
        /// </summary>
        /// <param name="contentManager">
        /// The content manager.
        /// </param>
        /// <param name="fontPath">
        /// The font path.
        /// </param>
        /// <param name="fontId">
        /// The font id.
        /// </param>
        private void LoadFont(ContentManager contentManager, string fontPath, string fontId)
        {
            this.fontContent[fontPath + fontId] = contentManager.Load<SpriteFont>(fontPath + fontId);
        }
    }
}
