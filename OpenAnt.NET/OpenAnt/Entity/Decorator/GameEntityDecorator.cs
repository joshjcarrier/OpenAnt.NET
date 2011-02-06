namespace OpenAnt.Entity.Decorator
{
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
        private GameEntityBase entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEntityDecorator"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity being decorated.
        /// </param>
        protected GameEntityDecorator(GameEntityBase entity) : base(entity.Position)
        {
            this.entity = entity;
        }

        /// <summary>
        /// Gets or sets Position.
        /// </summary>
        public override Rectangle Position
        {
            get { return this.entity.Position; }
            internal set { this.entity.Position = value; }
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

        public override void Move(Point newPosition)
        {
            this.entity.Move(newPosition);
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
