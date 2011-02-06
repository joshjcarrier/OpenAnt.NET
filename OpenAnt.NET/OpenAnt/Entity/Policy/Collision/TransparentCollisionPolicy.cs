namespace OpenAnt.Entity.Policy.Collision
{
    /// <summary>
    /// TransparentCollisionPolicy object, which can always be moved on.
    /// </summary>
    public class TransparentCollisionPolicy : CollisionPolicyBase
    {
        /// <summary>
        /// This policy allows any colliding entity to enter the collision zone.
        /// </summary>
        /// <param name="collidingEntity">
        /// The colliding entity.
        /// </param>
        /// <returns>
        /// True always.
        /// </returns>
        public override bool CollideOn(GameEntity collidingEntity)
        {
            return true;
        }
    }
}
