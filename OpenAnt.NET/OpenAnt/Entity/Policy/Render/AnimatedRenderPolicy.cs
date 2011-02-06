namespace OpenAnt.Entity.Policy.Render
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class AnimatedRenderPolicy : IRenderPolicy
    {
        private int animationFrame;

        private Texture2D[] animation;

        public AnimatedRenderPolicy(ContentProvider contentProvider, Point entitySize)
        {
            animation = new Texture2D[2];
            animation[0] = contentProvider.GetSpriteTexture(SpriteResource.YellowAntWalk1);
            animation[1] = contentProvider.GetSpriteTexture(SpriteResource.YellowAntWalk2);
            this.EntitySize = entitySize;
        }

        public Point EntitySize { get; private set; }

        public void Render(SpriteBatch spriteBatch, Point viewportPosition)
        {
            Texture2D texture;

            if(animationFrame<15)
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
                        this.EntitySize.X * HardCodes.TileSize,
                        this.EntitySize.Y * HardCodes.TileSize),
                Color.White);

            animationFrame += 1;
            animationFrame %= 30;
        }
    }
}
