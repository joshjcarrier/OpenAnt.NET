namespace OpenAnt.Entity.Decorator.Render
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Entity which is always represented by the same texture.
    /// </summary>
    public class StaticRenderEntity : GameEntityDecorator
    {
        /// <summary>
        /// The texture to render.
        /// </summary>
        private readonly Texture2D texture;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticRenderEntity"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity to decorate.
        /// </param>
        /// <param name="texture">
        /// The texture.
        /// </param>
        public StaticRenderEntity(GameEntityBase entity, Texture2D texture) : base(entity)
        {
            this.texture = texture;
        }

        /// <summary>
        /// Renders a static texture.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        /// <param name="viewportPosition">
        /// The viewport position.
        /// </param>
        public override void Render(SpriteBatch spriteBatch, Point viewportPosition)
        {
            var textureCoordinates = new Rectangle(
                viewportPosition.X * HardCodes.TileSize,
                viewportPosition.Y * HardCodes.TileSize,
                this.Position.Width * HardCodes.TileSize,
                this.Position.Height * HardCodes.TileSize);
            spriteBatch.Draw(this.texture, textureCoordinates, Color.White);
        }
    }
}
