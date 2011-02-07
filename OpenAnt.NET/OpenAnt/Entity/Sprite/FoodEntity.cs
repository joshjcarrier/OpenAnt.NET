namespace OpenAnt.Entity.Sprite
{
    using Microsoft.Xna.Framework;
    using Decorator.Collision;
    using Decorator.Interaction;
    using Decorator.Render;
    using Microsoft.Xna.Framework.Graphics;
    using Decorator.Intelligence;

    public static class FoodEntity
    {
        public static GameEntityBase Create(ContentProvider contentProvider, Point position)
        {
            var baseEntity = new GameEntityBase(new Rectangle(position.X, position.Y, 1, 1));
            baseEntity = new StaticRenderEntity(baseEntity, contentProvider.GetSpriteTexture(SpriteResource.Food1));
            return new CollisionBarrierEntity(baseEntity);
        }
    }
}
