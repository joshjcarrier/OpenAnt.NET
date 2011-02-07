namespace OpenAnt.Entity
{
    using Microsoft.Xna.Framework;
    using World;

    public class InteractableGameEntityBase : GameEntityBase
    {
        private INotifyWorldChangeRequested notifyWorldChangeRequested;

        public InteractableGameEntityBase(Rectangle position, INotifyWorldChangeRequested notifyWorldChangeRequested) : base(position)
        {
            this.notifyWorldChangeRequested = notifyWorldChangeRequested;
        }

        internal virtual INotifyWorldChangeRequested NotifyWorldChangeRequested 
        { 
            get { return this.notifyWorldChangeRequested; }
            set { this.notifyWorldChangeRequested = value; }
        }

        protected void OnNotifyWorldChangeRequested(Point targetLocation, object action)
        {
            this.NotifyWorldChangeRequested.OnNotifyWorldChangeRequested(this, targetLocation, action);
        }
    }
}
