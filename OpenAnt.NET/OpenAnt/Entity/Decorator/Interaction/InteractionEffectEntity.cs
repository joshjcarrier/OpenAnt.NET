namespace OpenAnt.Entity.Decorator.Interaction
{
    using Microsoft.Xna.Framework;
    using World;

    /// <summary>
    /// How to respond when an entity "interacts" with it.
    /// </summary>
    public class InteractionEffectEntity : GameEntityDecorator
    {
        public InteractionEffectEntity(GameEntityBase entity) : base(entity)
        {
        }

        public override void InteractWith(Point targetPoint)
        {
            //this.HoldingEntity = interactingEntity;
            this.OnNotifyWorldChangeRequested(targetPoint, ActionType.Interact);
        }
    }
}
