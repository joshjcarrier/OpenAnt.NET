namespace OpenAnt.Entity.Decorator.Render
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Entity which has an animation.
    /// </summary>
    public class AnimationRenderEntity : GameEntityDecorator
    {
        private int animationFrame;

        private Texture2D[] animation;

        public AnimationRenderEntity(GameEntityBase entity, ContentProvider contentProvider) : base(entity)
        {
            animation = new Texture2D[2];
            animation[0] = contentProvider.GetSpriteTexture(SpriteResource.YellowAntWalk1);
            animation[1] = contentProvider.GetSpriteTexture(SpriteResource.YellowAntWalk2);
        }

        public override void Render(SpriteBatch spriteBatch, Point viewportPosition)
        {
            Texture2D texture;

            if (animationFrame < 15)
            {
                texture = animation[0];
            }
            else
            {
                texture = animation[1];
            }

            spriteBatch.Draw(
                texture,
                new Rectangle(
                        ((int)viewportPosition.X) * HardCodes.TileSize,
                        ((int)viewportPosition.Y) * HardCodes.TileSize,
                        this.Position.Width * HardCodes.TileSize,
                        this.Position.Height * HardCodes.TileSize),
                Color.White);

            animationFrame += 1;
            animationFrame %= 30;
        }
    }
}
