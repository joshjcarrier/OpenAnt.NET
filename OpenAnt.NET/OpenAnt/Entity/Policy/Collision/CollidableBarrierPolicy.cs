namespace OpenAnt.Entity.Policy.Collision
{
    using System;

    /// <summary>
    /// Policy which always leaves the collision unresolvable.
    /// </summary>
    public class CollidableBarrierPolicy : CollisionPolicyBase
    {
        /// <summary>
        /// This policy does not allow the colliding entity to enter the collision zone.
        /// </summary>
        /// <param name="collidingEntity">
        /// The colliding entity.
        /// </param>
        /// <returns>
        /// False always.
        /// </returns>
        public override bool CollideOn(GameEntity collidingEntity)
        {
            return false;
        }
    }
}
