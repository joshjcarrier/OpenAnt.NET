namespace OpenAnt.Entity.Decorator
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using World;

    /// <summary>
    /// Allows decoration of the game entity.
    /// </summary>
    public abstract class GameEntityDecorator : GameEntityBase
    {
        /// <summary>
        /// The entity being decorated.
        /// </summary>
        private GameEntityBase entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEntityDecorator"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity being decorated.
        /// </param>
        protected GameEntityDecorator(GameEntityBase entity) 
            : base(entity.EntityType, entity.Position, entity.Allegiance, entity.NotifyWorldChangeRequested)
        {
            this.entity = entity;
        }

        /// <summary>
        /// Gets Allegiance.
        /// </summary>
        public override Player Allegiance
        {
            get { return this.entity.Allegiance; }
        }

        public override EntityType EntityType
        {
            get { return this.entity.EntityType; }
        }

        public override Orientation FacingDirection
        {
            get { return this.entity.FacingDirection; }
            set { this.entity.FacingDirection = value; }
        }

        public override int Health
        {
            get { return this.entity.Health; }
            set { this.entity.Health = value; }
        }

        internal override INotifyWorldChangeRequested NotifyWorldChangeRequested
        {
            get { return this.entity.NotifyWorldChangeRequested; }
            set { this.entity.NotifyWorldChangeRequested = value; }
        }

        /// <summary>
        /// Gets or sets Position.
        /// </summary>
        public override Rectangle Position
        {
            get { return this.entity.Position; }
            internal set { this.entity.Position = value; }
        }

        public override GameEntityBase HoldingEntity
        {
            get { return this.entity.HoldingEntity; }
            set { this.entity.HoldingEntity = value; }
        }

        #region Rendering Decoration

        public override void Render(SpriteBatch spriteBatch, Point viewportPosition)
        {
            this.entity.Render(spriteBatch, viewportPosition);
        }

        #endregion

        #region Collision Decoration

        public override bool CollideOn(GameEntityBase collidingEntity)
        {
            return this.entity.CollideOn(collidingEntity);
        }

        public override bool IsHitTestCollision(Point hitTestLocation)
        {
            return this.entity.IsHitTestCollision(hitTestLocation);
        }

        #endregion

        #region Interaction Decoration

        public override void Move(Point newPosition)
        {
            this.entity.Move(newPosition);
        }

        public override void InteractWith(Point targetPoint)
        {
            this.entity.InteractWith(targetPoint);
        }

        #endregion

        #region Intelligence Decorations
        public override Point UpdateAwareness()
        {
            return this.entity.UpdateAwareness();
        }
        #endregion
    }
}
