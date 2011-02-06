namespace OpenAnt.Entity.Decorator.Interaction
{
    /// <summary>
    /// How to respond when an entity "interacts" with it.
    /// </summary>
    public class InteractionEffectEntity : GameEntityDecorator
    {
        public InteractionEffectEntity(GameEntityBase entity) : base(entity)
        {
        }

        public override void InteractWith(GameEntityBase interactingEntity)
        {
            this.HoldingEntity = interactingEntity;
        }
    }
}
