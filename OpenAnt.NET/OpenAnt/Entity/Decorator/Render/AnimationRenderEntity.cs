using OpenAnt.Helper;

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

        public AnimationRenderEntity(GameEntityBase entity, Texture2D[] textureFrames)
            : base(entity)
        {
            this.animation = textureFrames;
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

            Rectangle spriteDestRect = new Rectangle(
                                                    viewportPosition.X * HardCodes.TileSize,
                                                    viewportPosition.Y * HardCodes.TileSize,
                                                    this.Position.Width * HardCodes.TileSize,
                                                    this.Position.Height * HardCodes.TileSize);
            spriteDestRect.Offset(spriteDestRect.Width / 2, spriteDestRect.Height / 2);

            spriteBatch.Draw(
                texture,
                spriteDestRect,
                null,
                Color.White,
                OrientationHelper.GetRotationAngle(FacingDirection),
                new Vector2(HardCodes.TextureSize / 2, HardCodes.TextureSize / 2),
                SpriteEffects.None,
                0f);

            animationFrame += 1;
            animationFrame %= 30;

            // TODO extract this to a base class
            if (this.HoldingEntity != null)
            {
                var heldEntityPosition = viewportPosition;
                var delta = OrientationHelper.GetAdjacentPointDelta(FacingDirection);
                heldEntityPosition.X += delta.X;
                heldEntityPosition.Y += delta.Y;

                this.HoldingEntity.Render(spriteBatch, heldEntityPosition);
            }
        }
    }
}
