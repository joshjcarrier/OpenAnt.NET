using OpenAnt.Helper;

namespace OpenAnt.Entity.Decorator.Interaction
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// An entity capable of having it's position changed in the world.
    /// </summary>
    public class MovingEntity : InteractableGameEntityDecorator
    {
        public MovingEntity(InteractableGameEntityBase entity) : base(entity)
        {
        }

        public override void Move(Point newPosition)
        {
            this.OnNotifyWorldChangeRequested(newPosition, ActionType.Move);
        }
    }
}
