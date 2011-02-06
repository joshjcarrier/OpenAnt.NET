namespace OpenAnt.Entity.Policy.Render
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Simple render of the same texture.
    /// </summary>
    public class StaticRenderPolicy : IRenderPolicy
    {
        private readonly Texture2D _texture;

        public StaticRenderPolicy(Texture2D texture, Point entitySize)
        {
            this._texture = texture;
            this.EntitySize = entitySize;
        }

        public Point EntitySize { get; private set; }

        public void Render(SpriteBatch spriteBatch, Point viewportPosition)
        {
            spriteBatch.Draw(
                this._texture, 
                new Rectangle(
                        ((int) viewportPosition.X) * HardCodes.TileSize,
                        ((int) viewportPosition.Y) * HardCodes.TileSize,
                        this.EntitySize.X * HardCodes.TileSize,
                        this.EntitySize.Y * HardCodes.TileSize),
                Color.White);
        }
    }
}
