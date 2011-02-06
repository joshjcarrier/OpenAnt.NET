namespace OpenAnt.Entity
{
    #region using directives
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Policy.Render;
    using Policy.Collision;

    #endregion

    /// <summary>
    /// Represents any game entity.
    /// </summary>
    public abstract class GameEntity : IRenderPolicy, ICollisionPolicy
    {
        /// <summary>
        /// The rendering policy.
        /// </summary>
        private readonly IRenderPolicy renderPolicy;

        /// <summary>
        /// The collision policy.
        /// </summary>
        private readonly ICollisionPolicy collisionPolicy;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEntity"/> class.
        /// </summary>
        /// <param name="renderPolicy">
        /// The render policy.
        /// </param>
        /// <param name="collisionPolicy">
        /// The collision policy.
        /// </param>
        /// <param name="position">
        /// The entity spatial position.
        /// </param>
        protected GameEntity(IRenderPolicy renderPolicy, ICollisionPolicy collisionPolicy, Rectangle position)
        {
            this.renderPolicy = renderPolicy;
            this.collisionPolicy = collisionPolicy;
            this.Position = position;
        }

        /// <summary>
        /// Gets or sets Position, as registered by the collision policy.
        /// </summary>
        public Rectangle Position
        {
            get { return this.collisionPolicy.Position; }
            set { this.collisionPolicy.Position = value; }
        }

        #region Rendering Policy

        public Point EntitySize
        {
            get { return new Point(Position.Width, Position.Height); }
        }

        public void Render(SpriteBatch spriteBatch, Point viewportPosition)
        {
            this.renderPolicy.Render(spriteBatch, viewportPosition);
        }
        #endregion

        #region Collision Policy
        public bool CollideOn(GameEntity collidingEntity)
        {
            return this.collisionPolicy.CollideOn(collidingEntity);
        }

        public bool IsHitTestCollision(Point hitTestLocation)
        {
            return this.collisionPolicy.IsHitTestCollision(hitTestLocation);
        }

        public void Move(Point position)
        {
            this.collisionPolicy.Move(position);
        }

        #endregion
    }
}
