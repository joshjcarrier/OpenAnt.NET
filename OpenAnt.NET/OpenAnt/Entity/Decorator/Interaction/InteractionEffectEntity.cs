namespace OpenAnt.Entity.Decorator.Interaction
{
    using Microsoft.Xna.Framework;
    using World;

    /// <summary>
    /// How to respond when an entity "interacts" with it.
    /// </summary>
    public class InteractionEffectEntity : GameEntityDecorator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionEffectEntity"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public InteractionEffectEntity(GameEntityBase entity) : base(entity)
        {
        }

        /// <summary>
        /// Decorator allowing interaction.
        /// </summary>
        /// <param name="targetPoint">
        /// The target point.
        /// </param>
        public override void InteractWith(Point targetPoint)
        {
            this.OnNotifyWorldChangeRequested(targetPoint, ActionType.Interact);
        }
    }
}
