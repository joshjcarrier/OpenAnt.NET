namespace OpenAnt.Entity.Decorator.Collision
{
    /// <summary>
    /// An unpassible entity.
    /// </summary>
    public class CollisionBarrierEntity : CollisionBaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollisionBarrierEntity"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity to decorate.
        /// </param>
        public CollisionBarrierEntity(GameEntityBase entity) : base(entity)
        {
        }

        /// <summary>
        /// This policy does not allow the colliding entity to enter the collision zone.
        /// </summary>
        /// <param name="collidingEntity">
        /// The colliding entity.
        /// </param>
        /// <returns>
        /// False always.
        /// </returns>
        public override bool CollideOn(GameEntityBase collidingEntity)
        {
            return false;
        }
    }
}
