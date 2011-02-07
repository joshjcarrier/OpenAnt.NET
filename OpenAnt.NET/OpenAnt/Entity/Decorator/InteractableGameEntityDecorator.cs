using OpenAnt.World;

namespace OpenAnt.Entity.Decorator
{
    public abstract class InteractableGameEntityDecorator : InteractableGameEntityBase
    {
        private InteractableGameEntityBase entity;

        protected InteractableGameEntityDecorator(InteractableGameEntityBase entity) : base(entity.Position, entity.NotifyWorldChangeRequested)
        {
            this.entity = entity;
        }

        internal override INotifyWorldChangeRequested NotifyWorldChangeRequested
        {
            get { return this.entity.NotifyWorldChangeRequested; }
            set { this.entity.NotifyWorldChangeRequested = value; }
        }
    }
}
