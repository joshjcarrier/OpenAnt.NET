namespace OpenAnt.Entity.Decorator
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Allows decoration of the game entity.
    /// </summary>
    public abstract class GameEntityDecorator : GameEntityBase
    {
        /// <summary>
        /// The entity being decorated.
        /// </summary>
        private readonly GameEntityBase entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEntityDecorator"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity being decorated.
        /// </param>
        protected GameEntityDecorator(GameEntityBase entity) 
            : base(entity.EntityType, entity.Position, entity.Allegiance)
        {
            this.entity = entity;
        }

        #region Properties

        /// <summary>
        /// Gets Allegiance.
        /// </summary>
        public override Player Allegiance
        {
            get { return this.entity.Allegiance; }
        }

        /// <summary>
        /// Gets EntityType.
        /// </summary>
        public override EntityType EntityType
        {
            get { return this.entity.EntityType; }
        }

        /// <summary>
        /// Gets or sets FacingDirection.
        /// </summary>
        public override Orientation FacingDirection
        {
            get { return this.entity.FacingDirection; }
            set { this.entity.FacingDirection = value; }
        }

        /// <summary>
        /// Gets or sets Health.
        /// </summary>
        public override int Health
        {
            get { return this.entity.Health; }
            set { this.entity.Health = value; }
        }
        
        /// <summary>
        /// Gets or sets Position.
        /// </summary>
        public override Rectangle Position
        {
            get { return this.entity.Position; }
            internal set { this.entity.Position = value; }
        }

        /// <summary>
        /// Gets or sets HoldingEntity.
        /// </summary>
        public override GameEntityBase HoldingEntity
        {
            get { return this.entity.HoldingEntity; }
            set { this.entity.HoldingEntity = value; }
        }

        #endregion

        #region Rendering Decoration

        /// <summary>
        /// Renders the entity.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        /// <param name="viewportPosition">
        /// The viewport position.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Entity must be decorated to be invoked.
        /// </exception>
        public override void Render(SpriteBatch spriteBatch, Point viewportPosition)
        {
            this.entity.Render(spriteBatch, viewportPosition);
        }

        #endregion

        #region Collision Decoration

        /// <summary>
        /// Collide the entity on the given colliding entity.
        /// </summary>
        /// <param name="collidingEntity">
        /// The colliding entity.
        /// </param>
        /// <returns>
        /// True on collision.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Entity must be decorated to be invoked.
        /// </exception>
        public override bool CollideOn(GameEntityBase collidingEntity)
        {
            return this.entity.CollideOn(collidingEntity);
        }

        /// <summary>
        /// Tests to see if entity collides with another at the given location.
        /// </summary>
        /// <param name="hitTestLocation">
        /// The hit test location.
        /// </param>
        /// <returns>
        /// True if a collision with an entity in the location.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Entity must be decorated to be invoked.
        /// </exception>
        public override bool IsHitTestCollision(Point hitTestLocation)
        {
            return this.entity.IsHitTestCollision(hitTestLocation);
        }

        #endregion

        #region Interaction Decoration

        /// <summary>
        /// Decorator allowing movement.
        /// </summary>
        /// <param name="newPosition">
        /// The new position.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Entity must be decorated to be invoked.
        /// </exception>
        public override void Move(Point newPosition)
        {
            this.entity.Move(newPosition);
        }

        /// <summary>
        /// Decorator allowing interaction.
        /// </summary>
        /// <param name="targetPoint">
        /// The target point.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Entity must be decorated to be invoked.
        /// </exception>
        public override void InteractWith(Point targetPoint)
        {
            this.entity.InteractWith(targetPoint);
        }

        #endregion

        #region Intelligence Decorations
        /// <summary>
        /// Decorator allowing entity artificial intelligence.
        /// </summary>
        /// <returns>
        /// The position decided to move to.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Entity must be decorated to be invoked.
        /// </exception>
        public override Point UpdateAwareness()
        {
            return this.entity.UpdateAwareness();
        }
        #endregion
    }
}
