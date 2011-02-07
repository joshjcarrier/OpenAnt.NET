namespace OpenAnt.Entity.Decorator.Render
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Helper;

    /// <summary>
    /// Entity which has an animation.
    /// </summary>
    public class AnimationRenderEntity : GameEntityDecorator
    {
        /// <summary>
        /// The animation texture frames.
        /// </summary>
        private readonly Texture2D[] animation;

        /// <summary>
        /// The current animation frame.
        /// </summary>
        private int animationFrame;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimationRenderEntity"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="textureFrames">
        /// The texture frames.
        /// </param>
        public AnimationRenderEntity(GameEntityBase entity, Texture2D[] textureFrames)
            : base(entity)
        {
            this.animation = textureFrames;
        }

        /// <summary>
        /// Renders the entity.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        /// <param name="viewportPosition">
        /// The viewport position.
        /// </param>
        public override void Render(SpriteBatch spriteBatch, Point viewportPosition)
        {
            Texture2D texture;

            if (this.animationFrame < 15)
            {
                texture = this.animation[0];
            }
            else
            {
                texture = this.animation[1];
            }

            var spriteDestRect = new Rectangle(
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

            this.animationFrame += 1;
            this.animationFrame %= 30;

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
