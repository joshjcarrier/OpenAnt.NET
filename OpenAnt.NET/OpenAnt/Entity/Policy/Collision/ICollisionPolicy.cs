using Microsoft.Xna.Framework;

namespace OpenAnt.Entity.Policy.Collision
{
    /// <summary>
    /// Collidable interface.
    /// </summary>
    public interface ICollisionPolicy
    {
        Rectangle Position { get; set; }

        /// <summary>
        /// Collision attempting to move on top of the colliding entity.
        /// </summary>
        /// <param name="collidingEntity">
        /// The entity to collide on to.
        /// </param>
        /// <returns>
        /// True if the collision was resolved.
        /// </returns>
        bool CollideOn(GameEntity collidingEntity);

        /// <summary>
        /// Detects if a collision with the hit test location.
        /// </summary>
        /// <param name="hitTestLocation">
        /// The location to hit test.
        /// </param>
        /// <returns>
        /// True if there is a hit-test collision with the entity.
        /// </returns>
        bool IsHitTestCollision(Point hitTestLocation);

        /// <summary>
        /// Moves the entity to the given position.
        /// </summary>
        /// <param name="position">
        /// The position.
        /// </param>
        void Move(Point position);
    }
}
