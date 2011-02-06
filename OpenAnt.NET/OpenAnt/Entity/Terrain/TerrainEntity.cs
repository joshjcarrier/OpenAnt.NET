namespace OpenAnt.Entity.Terrain
{
    #region using directives
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Decorator.Collision;
    using Decorator.Render;
    #endregion

    /// <summary>
    /// Terrain-type entity.
    /// </summary>
    public static class TerrainEntity
    {
        /// <summary>
        /// Creates a surface-type terrain tile.
        /// </summary>
        /// <param name="texture">
        /// The texture.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// A surface-type terrain tile.
        /// </returns>
        public static GameEntityBase CreateSurface(Texture2D texture, Point position)
        {
            var baseEntity = new GameEntityBase(new Rectangle(position.X, position.Y, 1, 1));
            var renderableEntity = new StaticRenderEntity(baseEntity, texture);
            return new TransparentCollisionEntity(renderableEntity);
        }

        /// <summary>
        /// Creates an obstacle-type terrain.
        /// </summary>
        /// <param name="texture">
        /// The texture.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <param name="size">
        /// The size of the obstacle.
        /// </param>
        /// <returns>
        /// An obstacle-type terrain.
        /// </returns>
        public static GameEntityBase CreateObstacle(Texture2D texture, Point position, int size)
        {
            var baseEntity = new GameEntityBase(new Rectangle(position.X, position.Y, size, size));
            var renderableEntity = new StaticRenderEntity(baseEntity, texture);
            return new CollisionBarrierEntity(renderableEntity);
        }
    }
}
