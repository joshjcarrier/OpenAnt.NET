namespace OpenAnt.Entity.Policy.Collision
{
    using Microsoft.Xna.Framework;

    public abstract class CollisionPolicyBase : ICollisionPolicy
    {
        private Rectangle position;
        public Rectangle Position
        {
            get { return position; }
            set { this.position = value; }
        }

        public abstract bool CollideOn(GameEntity collidingEntity);

        public bool IsHitTestCollision(Point hitTestLocation)
        {
            return this.Position.Contains(hitTestLocation);
        }

        public void Move(Point position)
        {
            this.position.Location = position;
        }
    }
}
