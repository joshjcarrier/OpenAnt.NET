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
        /// Initializes a new instance of the <see cref="GameEntityBase"/> class.
        /// </summary>
        /// <param name="position">
        /// The entity spatial position.
        /// </param>
        public GameEntityBase(Rectangle position)
        {
            this.Position = position;
        }

        /// <summary>
        /// Gets or sets Position, as registered by the collision policy.
        /// </summary>
        public Rectangle Position { get; protected set; }

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

        public virtual void Move(Point newPosition)
        {
            throw new InvalidOperationException("Decorator not defined.");
        }

        #endregion
    }
}
