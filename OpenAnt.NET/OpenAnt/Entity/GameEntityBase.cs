namespace OpenAnt.Entity
{
    #region using directives
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using World;

    #endregion

    /// <summary>
    /// Represents any game entity.
    /// </summary>
    public class GameEntityBase
    {
        private Rectangle position;
        private INotifyWorldChangeRequested notifyWorldChangeRequested;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEntityBase"/> class.
        /// </summary>
        /// <param name="position">
        /// The entity spatial position.
        /// </param>
        public GameEntityBase(Rectangle position, INotifyWorldChangeRequested notifyWorldChangeRequested)
        {
            this.position = position;
            this.notifyWorldChangeRequested = notifyWorldChangeRequested;
        }

        public virtual Orientation FacingDirection { get; set; }

        /// <summary>
        /// Gets the Position.
        /// </summary>
        public virtual Rectangle Position
        {
            get { return this.position; }
            internal set { this.position = value; }
        }

        public virtual GameEntityBase HoldingEntity { get; set; }

        #region World Change Request
        internal virtual INotifyWorldChangeRequested NotifyWorldChangeRequested
        {
            get { return this.notifyWorldChangeRequested; }
            set { this.notifyWorldChangeRequested = value; }
        }

        protected void OnNotifyWorldChangeRequested(Point targetLocation, object action)
        {
            this.NotifyWorldChangeRequested.OnNotifyWorldChangeRequested(this, targetLocation, action);
        }
        #endregion

        #region Rendering Decorations

        public virtual void Render(SpriteBatch spriteBatch, Point viewportPosition)
        {
            throw new InvalidOperationException("Decorator not defined.");
        }

        #endregion

        #region Collision Decorations

        public virtual bool CollideOn(GameEntityBase collidingEntity)
        {
            throw new InvalidOperationException("Decorator not defined.");
        }

        public virtual bool IsHitTestCollision(Point hitTestLocation)
        {
            throw new InvalidOperationException("Decorator not defined.");
        }

        #endregion

        #region Intelligence Decorations

        public virtual Point UpdateAwareness()
        {
            throw new InvalidOperationException("Decorator not defined.");
        }

        #endregion

        #region Interaction Decorations
        public virtual void Move(Point newPosition)
        {
            throw new InvalidOperationException("Decorator not defined.");
        }

        public virtual void InteractWith(GameEntityBase interactingEntity)
        {
            throw new InvalidOperationException("Decorator not defined.");
        }
        #endregion
    }
}
