using Microsoft.Xna.Framework;
using OpenAnt.Helper;

namespace OpenAnt.Entity.Decorator.Interaction
{
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
