namespace OpenAnt.Entity.Decorator.Render
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Entity which is always represented by the same texture.
    /// </summary>
    public class StaticRenderEntity : GameEntityDecorator
    {
        private Texture2D texture;

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

        public override void Render(SpriteBatch spriteBatch, Point viewportPosition)
        {
            spriteBatch.Draw(
                this.texture,
                new Rectangle(
                        ((int)viewportPosition.X) * HardCodes.TileSize,
                        ((int)viewportPosition.Y) * HardCodes.TileSize,
                        this.Position.Width * HardCodes.TileSize,
                        this.Position.Height * HardCodes.TileSize),
                Color.White);
        }
    }
}
