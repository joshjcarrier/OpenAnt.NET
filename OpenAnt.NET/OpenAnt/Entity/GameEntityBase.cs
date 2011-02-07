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
        private Player allegiance;
        private EntityType entityType;
        private int health;
        private Rectangle position;
        private INotifyWorldChangeRequested notifyWorldChangeRequested;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEntityBase"/> class.
        /// </summary>
        /// <param name="type">
        /// The type of entity being represented.
        /// </param>
        /// <param name="position">
        /// The entity spatial position.
        /// </param>
        public GameEntityBase(EntityType type, Rectangle position) : this(type, position, Player.Gaia, null)
        {
        }

        public GameEntityBase(EntityType type, Rectangle position, Player allegiance, INotifyWorldChangeRequested notifyWorldChangeRequested)
        {
            this.allegiance = allegiance;
            this.entityType = type;
            this.health = 1000;
            this.notifyWorldChangeRequested = notifyWorldChangeRequested;
            this.position = position;
        }

        /// <summary>
        /// Gets Allegiance.
        /// </summary>
        public virtual Player Allegiance
        {
            get { return this.allegiance; }
        }

        /// <summary>
        /// Gets EntityType.
        /// </summary>
        public virtual EntityType EntityType
        {
            get { return this.entityType; }
        }

        /// <summary>
        /// Gets or sets FacingDirection.
        /// </summary>
        public virtual Orientation FacingDirection { get; set; }

        /// <summary>
        /// Gets or sets Health.
        /// </summary>
        public virtual int Health
        {
            get { return this.health; }
            set { this.health = value; }
        }

        /// <summary>
        /// Gets the Position.
        /// </summary>
        public virtual Rectangle Position
        {
            get { return this.position; }
            internal set { this.position = value; }
        }

        /// <summary>
        /// Gets or sets HoldingEntity.
        /// </summary>
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

        public virtual void InteractWith(Point targetPoint)
        {
            throw new InvalidOperationException("Decorator not defined.");
        }
        #endregion
    }
}
