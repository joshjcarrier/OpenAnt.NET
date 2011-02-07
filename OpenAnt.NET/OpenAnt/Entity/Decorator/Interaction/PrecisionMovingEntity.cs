namespace OpenAnt.Entity.Decorator.Interaction
{
    using Microsoft.Xna.Framework;

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
            OnNotifyWorldChangeRequested(newPosition, ActionType.PrecisionMove);
        }
    }
}
