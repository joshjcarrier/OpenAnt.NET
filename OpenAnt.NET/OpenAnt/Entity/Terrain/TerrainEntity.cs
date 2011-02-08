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
            var baseEntity = new GameEntityBase(EntityType.TerrainSurface, new Rectangle(position.X, position.Y, 1, 1));
            baseEntity = new StaticRenderEntity(baseEntity, texture);
            return new TransparentCollisionEntity(baseEntity);
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
            var baseEntity = new GameEntityBase(EntityType.TerrainObstacle, new Rectangle(position.X, position.Y, size, size));
            baseEntity = new StaticRenderEntity(baseEntity, texture);
            return new CollisionBarrierEntity(baseEntity);
        }

        /// <summary>
        /// Creates soil-type terrain tile.
        /// </summary>
        /// <param name="texture">
        /// The texture.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// A soil-type terrain tile.
        /// </returns>
        public static GameEntityBase CreateSoil(Texture2D texture, Point position)
        {
            var tint = Color.White;
            var depth = position.Y;
            if (depth > 0)
            {
                tint = Color.SaddleBrown;
            }

            var baseEntity = new GameEntityBase(EntityType.TerrainSurface, new Rectangle(position.X, position.Y, 1, 1));
            baseEntity = new StaticRenderEntity(baseEntity, texture, tint);
            return new TransparentCollisionEntity(baseEntity);
        }

        /// <summary>
        /// Creates underground-type terrain tile.
        /// </summary>
        /// <param name="texture">
        /// The texture.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// A underground-type terrain tile.
        /// </returns>
        public static GameEntityBase CreateUnderground(Texture2D texture, Point position)
        {
            var tint = Color.White;
            var depth = position.Y;
            if (depth > 0)
            {
                tint = Color.SaddleBrown;
            }

            var baseEntity = new GameEntityBase(EntityType.TerrainSurface, new Rectangle(position.X, position.Y, 1, 1));
            baseEntity = new StaticRenderEntity(baseEntity, texture, tint);
            return new TransparentCollisionEntity(baseEntity);
        }
    }
}
