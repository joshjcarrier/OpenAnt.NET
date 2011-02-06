using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace OpenAnt
{
    #region using directives
    using Microsoft.Xna.Framework.Content;
    #endregion

    public class ContentProvider
    {
        private IDictionary<string, Texture2D> content;
        private Texture2D nullTexture;

        public ContentProvider(ContentManager contentManager, Texture2D nullTexture)
        {
            content = new Dictionary<string, Texture2D>();
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
        }

        public Texture2D GetSpriteTexture(string spriteTextureId)
        {
            return this.GetTexture(HardCodes.SpriteContent + spriteTextureId);
        }

        public Texture2D GetTerrainTexture(string terrainTextureId)
        {
            return this.GetTexture(HardCodes.TerrainContent + terrainTextureId);
        }

        private Texture2D GetTexture(string textureId)
        {
            Texture2D content;
            if (!this.content.TryGetValue(textureId, out content))
            {
                return this.nullTexture;
            }

            return content;
        }

        private void LoadTexture(ContentManager contentManager, string textureContent, string textureId)
        {
            content[textureContent + textureId] = contentManager.Load<Texture2D>(textureContent + textureId);
        }
    }
}
