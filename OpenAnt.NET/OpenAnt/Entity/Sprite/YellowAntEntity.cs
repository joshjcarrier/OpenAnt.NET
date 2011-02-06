namespace OpenAnt.Entity.Sprite
{
    using Microsoft.Xna.Framework;
    using Decorator.Collision;
    using Decorator.Render;

    /// <summary>
    /// Yellow ant entity.
    /// </summary>
    public class YellowAntEntity
    {
        public static GameEntityBase Create(ContentProvider contentProvider, Point position)
        {
            var baseEntity = new GameEntityBase(new Rectangle(position.X, position.Y, 1, 1));
            var renderableEntity = new AnimationRenderEntity(baseEntity, contentProvider);
            return new CollisionBarrierEntity(renderableEntity);
        }
    }
}
