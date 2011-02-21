namespace OpenAnt.Entity.Decorator.Interaction
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// An entity capable of having it's position changed in the world.
    /// </summary>
    public class MovingEntity : GameEntityDecorator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MovingEntity"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public MovingEntity(GameEntityBase entity) : base(entity)
        {
        }

        /// <summary>
        /// Decorator allowing movement.
        /// </summary>
        /// <param name="newPosition">
        /// The new position.
        /// </param>
        public override void Move(Point newPosition)
        {
            //// this.OnNotifyWorldChangeRequested(newPosition, ActionType.Move);
        }
    }
}
