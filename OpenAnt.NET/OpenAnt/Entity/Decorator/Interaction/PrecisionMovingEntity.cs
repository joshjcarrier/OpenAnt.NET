namespace OpenAnt.Entity.Decorator.Interaction
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Requires the entity to be facing the direction it's moving first.
    /// </summary>
    public class PrecisionMovingEntity : MovingEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrecisionMovingEntity"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public PrecisionMovingEntity(GameEntityBase entity) : base(entity)
        {
        }

        /// <summary>
        /// Perform a precision (face direction first) move operation request.
        /// </summary>
        /// <param name="newPosition">
        /// The new position.
        /// </param>
        public override void Move(Point newPosition)
        {
            // OnNotifyWorldChangeRequested(newPosition, ActionType.PrecisionMove);
        }
    }
}
