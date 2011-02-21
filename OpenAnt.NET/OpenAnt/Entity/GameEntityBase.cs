namespace OpenAnt.Entity
{
    #region using directives
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// Represents any game entity.
    /// </summary>
    public class GameEntityBase
    {
        /// <summary>
        /// The allegiance of the entity.
        /// </summary>
        private readonly Player allegiance;

        /// <summary>
        /// The type of entity being represented.
        /// </summary>
        private readonly EntityType entityType;

        /// <summary>
        /// The health of the entity.
        /// </summary>
        private int health;

        /// <summary>
        /// The position of the entity.
        /// </summary>
        private Rectangle position;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEntityBase"/> class.
        /// </summary>
        /// <param name="type">
        /// The type of entity being represented.
        /// </param>
        /// <param name="position">
        /// The entity spatial position.
        /// </param>
        public GameEntityBase(EntityType type, Rectangle position) : this(type, position, Player.Gaia)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEntityBase"/> class.
        /// </summary>
        /// <param name="type">
        /// The type of entity being represented.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <param name="allegiance">
        /// The allegiance.
        /// </param>
        public GameEntityBase(EntityType type, Rectangle position, Player allegiance)
        {
            this.allegiance = allegiance;
            this.entityType = type;
            this.health = 1000;
            this.position = position;
        }

        #region Properties
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
        
        #endregion

        #region Rendering Decorations

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
        public virtual void Render(SpriteBatch spriteBatch, Point viewportPosition)
        {
            throw new InvalidOperationException("Decorator not defined.");
        }

        #endregion

        #region Collision Decorations

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
        public virtual bool CollideOn(GameEntityBase collidingEntity)
        {
            throw new InvalidOperationException("Decorator not defined.");
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
        public virtual bool IsHitTestCollision(Point hitTestLocation)
        {
            throw new InvalidOperationException("Decorator not defined.");
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
        public virtual Point UpdateAwareness()
        {
            throw new InvalidOperationException("Decorator not defined.");
        }

        #endregion

        #region Interaction Decorations

        /// <summary>
        /// Decorator allowing movement.
        /// </summary>
        /// <param name="newPosition">
        /// The new position.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Entity must be decorated to be invoked.
        /// </exception>
        public virtual void Move(Point newPosition)
        {
            throw new InvalidOperationException("Decorator not defined.");
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
        public virtual void InteractWith(Point targetPoint)
        {
            throw new InvalidOperationException("Decorator not defined.");
        }
        #endregion      
    }
}
