namespace OpenAnt.Services
{
    using Data;
    using Entity;
    using Entity.Sprite;
    using Entity.Terrain;

    /// <summary>
    /// Generates game entities from world tiles.
    /// </summary>
    public class EntityFactory
    {
        /// <summary>
        /// The content provider.
        /// </summary>
        private readonly ContentProvider contentProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityFactory"/> class.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        public EntityFactory(ContentProvider contentProvider)
        {
            this.contentProvider = contentProvider;
        }

        /// <summary>
        /// Generates a game entity from a world data.
        /// </summary>
        /// <param name="data">
        /// The data to generate from.
        /// </param>
        /// <returns>
        /// A game entity.
        /// </returns>
        public GameEntityBase Create(WorldData data)
        {
            // TODO better conversion
            switch (data.Type)
            {
                case EntityType.TerrainSurface:
                    return TerrainEntity.CreateSurface(this.contentProvider.GetTerrainTexture(data.Subtype), data.Position);
                case EntityType.TerrainObstacle:
                    return TerrainEntity.CreateObstacle(this.contentProvider.GetTerrainTexture(data.Subtype), data.Position, data.Size);
                case EntityType.Ant:
                    return YellowAntEntity.Create(this.contentProvider, data.Position);
            }

            return null;
        }
    }
}
