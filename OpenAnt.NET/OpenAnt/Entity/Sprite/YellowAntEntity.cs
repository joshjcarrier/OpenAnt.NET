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
        public static GameEntityBase Create(ContentProvider contentProvider, Point position)
        {
            var animation = new Texture2D[2];
            animation[0] = contentProvider.GetSpriteTexture(SpriteResource.YellowAntWalk1);
            animation[1] = contentProvider.GetSpriteTexture(SpriteResource.YellowAntWalk2);

            var baseEntity = new GameEntityBase(new Rectangle(position.X, position.Y, 1, 1));
            baseEntity = new AnimationRenderEntity(baseEntity, animation);
            baseEntity = new CollisionBarrierEntity(baseEntity);
            baseEntity = new PrecisionMovingEntity(baseEntity);
            return new InteractionEffectEntity(baseEntity);
        }
    }
}
