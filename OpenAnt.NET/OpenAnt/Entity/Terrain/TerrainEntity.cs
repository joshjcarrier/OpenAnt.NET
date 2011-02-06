namespace OpenAnt.Entity.Terrain
{
    #region using directives
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Policy.Collision;
    using Policy.Render;
    #endregion

    /// <summary>
    /// Terrain-type entity.
    /// </summary>
    public class TerrainEntity : GameEntity
    {
        protected TerrainEntity(IRenderPolicy renderPolicy, ICollisionPolicy collisionPolicy, Rectangle position) : base(renderPolicy, collisionPolicy, position)
        {
        }

        public static GameEntity Create(Texture2D texture, Point position)
        {
            var renderable = new StaticRenderPolicy(texture, new Point(1, 1));
            var collidable = new TransparentCollisionPolicy();
            return new TerrainEntity(renderable, collidable, new Rectangle(position.X, position.Y, 1, 1));
        }
    }
}
