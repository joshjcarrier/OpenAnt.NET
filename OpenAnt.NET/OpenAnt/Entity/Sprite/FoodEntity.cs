namespace OpenAnt.Entity.Sprite
{
    using Microsoft.Xna.Framework;
    using Decorator.Collision;
    using Decorator.Render;

    /// <summary>
    /// Generates food entities.
    /// </summary>
    public static class FoodEntity
    {
        /// <summary>
        /// Generates a random food entity.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// A random food entity.
        /// </returns>
        public static GameEntityBase Create(ContentProvider contentProvider, Point position)
        {
            var baseEntity = new GameEntityBase(EntityType.Food, new Rectangle(position.X, position.Y, 1, 1));
            baseEntity = new StaticRenderEntity(baseEntity, contentProvider.GetSpriteTexture(SpriteResource.Food1));
            return new CollisionBarrierEntity(baseEntity);
        }
    }
}
