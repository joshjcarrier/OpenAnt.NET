namespace OpenAnt.Entity.Decorator.Collision
{
    /// <summary>
    /// TransparentCollisionPolicy object, which can always be moved on.
    /// </summary>
    public class TransparentCollisionEntity : CollisionBaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransparentCollisionEntity"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity to decorate.
        /// </param>
        public TransparentCollisionEntity(GameEntityBase entity) : base(entity)
        {
        }

        /// <summary>
        /// This policy allows any colliding entity to enter the collision zone.
        /// </summary>
        /// <param name="collidingEntity">
        /// The colliding entity.
        /// </param>
        /// <returns>
        /// True always.
        /// </returns>
        public override bool CollideOn(GameEntityBase collidingEntity)
        {
            return true;
        }
    }
}
