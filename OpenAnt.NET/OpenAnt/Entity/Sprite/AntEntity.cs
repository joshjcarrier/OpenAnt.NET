namespace OpenAnt.Entity.Sprite
{
    using Microsoft.Xna.Framework;
    using Decorator.Collision;
    using Decorator.Interaction;
    using Decorator.Render;
    using Microsoft.Xna.Framework.Graphics;
    using Decorator.Intelligence;

    public static class AntEntity
    {
        public static GameEntityBase Create(ContentProvider contentProvider, Point position)
        {
            var animation = new Texture2D[2];
            animation[0] = contentProvider.GetSpriteTexture(SpriteResource.YellowAntWalk1);
            animation[1] = contentProvider.GetSpriteTexture(SpriteResource.YellowAntWalk2);

            var baseEntity = new GameEntityBase(new Rectangle(position.X, position.Y, 1, 1));
            baseEntity = new AnimationRenderEntity(baseEntity, animation);
            baseEntity = new CollisionBarrierEntity(baseEntity);
            baseEntity = new MovingEntity(baseEntity);
            return new WorkerAntIntelligence(baseEntity);
        }
    }
}
