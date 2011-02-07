namespace OpenAnt.Entity.Sprite
{
    using Microsoft.Xna.Framework;
    using Decorator.Collision;
    using Decorator.Render;

    public static class FoodEntity
    {
        public static GameEntityBase Create(ContentProvider contentProvider, Point position)
        {
            var baseEntity = new GameEntityBase(EntityType.Food, new Rectangle(position.X, position.Y, 1, 1));
            baseEntity = new StaticRenderEntity(baseEntity, contentProvider.GetSpriteTexture(SpriteResource.Food1));
            return new CollisionBarrierEntity(baseEntity);
        }
    }
}
