namespace OpenAnt.Entity.Decorator.Interaction
{
    using Microsoft.Xna.Framework;
    using Helper;

    /// <summary>
    /// Requires the entity to be facing the direction it's moving first.
    /// </summary>
    public class PrecisionMovingEntity : MovingEntity
    {
        public PrecisionMovingEntity(GameEntityBase entity) : base(entity)
        {
        }

        public override void Move(Point newPosition)
        {
            // TODO generate events instead of actually manipulating the sprite object
            // OnNotifyWorldChangeRequested(newPosition, null);
            var oldPosition = Position.Location;
            var newOrientation = OrientationHelper.GetFacingDirection(oldPosition, newPosition);

            if (newOrientation == FacingDirection)
            {
                var rect = Position;
                rect.Location = newPosition;
                Position = rect;
            }
            else
            {
                FacingDirection = newOrientation;
            }
        }
    }
}
