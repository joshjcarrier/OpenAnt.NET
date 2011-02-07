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
            // TODO generate events instead of actually manipulating the sprite object
            // this.OnNotifyWorldChangeRequested(newPosition, null);
            var oldPosition = Position.Location;
            var newOrientation = OrientationHelper.GetFacingDirection(oldPosition, newPosition);

            var rect = Position;
            rect.Location = newPosition;
            Position = rect;
            FacingDirection = newOrientation;
        }
    }
}
