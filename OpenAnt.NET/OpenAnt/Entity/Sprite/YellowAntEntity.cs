namespace OpenAnt.Entity.Sprite
{
    using Microsoft.Xna.Framework;
    using Decorator.Collision;
    using Decorator.Render;
    using Decorator.Interaction;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Yellow ant entity.
    /// </summary>
    public class YellowAntEntity
    {
        /// <summary>
        /// Creates a new yellow ant entity.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// A yellow ant.
        /// </returns>
        public static GameEntityBase Create(ContentProvider contentProvider, Point position)
        {
            var animation = new Texture2D[2];
            animation[0] = contentProvider.GetSpriteTexture(SpriteResource.YellowAntWalk1);
            animation[1] = contentProvider.GetSpriteTexture(SpriteResource.YellowAntWalk2);

            // apply interactive elements first
            var baseEntity = new GameEntityBase(EntityType.Ant, new Rectangle(position.X, position.Y, 1, 1), Player.Black);
            baseEntity = new PrecisionMovingEntity(baseEntity);
            baseEntity = new AnimationRenderEntity(baseEntity, animation);
            baseEntity = new CollisionBarrierEntity(baseEntity);
            return new InteractionEffectEntity(baseEntity);
        }
    }
}
