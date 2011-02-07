namespace OpenAnt.Entity.Decorator.Collision
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Registers common collision logistics.
    /// </summary>
    public abstract class CollisionBaseEntity : GameEntityDecorator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollisionBaseEntity"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity to decorate.
        /// </param>
        protected CollisionBaseEntity(GameEntityBase entity) : base(entity)
        {
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
        public override bool IsHitTestCollision(Point hitTestLocation)
        {
            return this.Position.Contains(hitTestLocation);
        }
    }
}
