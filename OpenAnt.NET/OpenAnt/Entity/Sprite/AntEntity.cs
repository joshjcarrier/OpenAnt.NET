using OpenAnt.World;

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
        public static GameEntityBase Create(ContentProvider contentProvider, Point position, INotifyWorldChangeRequested notifyWorldChangeRequested)
        {
            var animation = new Texture2D[2];
            animation[0] = contentProvider.GetSpriteTexture(SpriteResource.YellowAntWalk1);
            animation[1] = contentProvider.GetSpriteTexture(SpriteResource.YellowAntWalk2);

            // apply interactive elements first
            var interactableEntity = new InteractableGameEntityBase(new Rectangle(position.X, position.Y, 1, 1), notifyWorldChangeRequested);
            interactableEntity = new MovingEntity(interactableEntity);

            GameEntityBase baseEntity = new AnimationRenderEntity(interactableEntity, animation);
            baseEntity = new CollisionBarrierEntity(baseEntity);
            return new WorkerAntIntelligence(baseEntity);
        }
    }
}
