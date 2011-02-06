namespace OpenAnt.Entity.Terrain
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Policy.Collision;
    using Policy.Render;

    public class TerrainObstacleEntity : GameEntity
    {
        protected TerrainObstacleEntity(IRenderPolicy renderPolicy, ICollisionPolicy collisionPolicy, Rectangle position) 
            : base(renderPolicy, collisionPolicy, position)
        {
        }

        public static GameEntity Create(Texture2D texture, Point position, int size)
        {          
            var renderable = new StaticRenderPolicy(texture, new Point(size, size));
            var collidable = new CollidableBarrierPolicy();
            return new TerrainObstacleEntity(renderable, collidable, new Rectangle(position.X, position.Y, size, size));
        }
    }
}
