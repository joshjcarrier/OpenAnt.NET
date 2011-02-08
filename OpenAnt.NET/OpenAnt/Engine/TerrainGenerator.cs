namespace OpenAnt.Engine
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Entity;
    using Entity.Terrain;

    /// <summary>
    /// Generates Terrain-based tiles.
    /// </summary>
    public static class TerrainGenerator
    {
        /// <summary>
        /// Random number generator used to create new worlds.
        /// </summary>
        private static readonly Random RandomGen = new Random();

        /// <summary>
        /// Generates a surface terrain.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// A random surface terrain.
        /// </returns>
        public static GameEntityBase MakeSurface(ContentProvider contentProvider, Point position)
        {
            var thing = RandomGen.Next(0, 100);
            Texture2D texture;
            if (thing > 98)
            {
                texture = contentProvider.GetTerrainTexture(TerrainResource.Ground4);
            }
            else if (thing > 35)
            {
                texture = contentProvider.GetTerrainTexture(TerrainResource.Ground1);
            }
            else if (thing > 25)
            {
                texture = contentProvider.GetTerrainTexture(TerrainResource.Ground2);
            }
            else if (thing > 13)
            {
                texture = contentProvider.GetTerrainTexture(TerrainResource.Ground3);
            }
            else if (thing > 8)
            {
                texture = contentProvider.GetTerrainTexture(TerrainResource.Foliage1);
            }
            else if (thing > 3)
            {
                texture = contentProvider.GetTerrainTexture(TerrainResource.Foliage2);
            }
            else
            {
                texture = contentProvider.GetTerrainTexture(TerrainResource.Foliage3);
            }

            return TerrainEntity.CreateSurface(texture, position);
        }

        /// <summary>
        /// Generates a random terrain obstacle.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// A random terrain obstacle.
        /// </returns>
        public static GameEntityBase MakeObstacle(ContentProvider contentProvider, Point position)
        {
            var thing = RandomGen.Next(0, 100);
            Texture2D texture;
            int size = 1;
            if (thing > 92)
            {
                texture = contentProvider.GetTerrainTexture(TerrainResource.GroundRock4);
                size = 2;
            }
            else if (thing > 80)
            {
                texture = contentProvider.GetTerrainTexture(TerrainResource.Rock1);
            }
            else if (thing > 35)
            {
                texture = contentProvider.GetTerrainTexture(TerrainResource.Rock2);
            }
            else
            {
                texture = contentProvider.GetTerrainTexture(TerrainResource.Rock3);
            }

            return TerrainEntity.CreateObstacle(texture, position, size);
        }

        /// <summary>
        /// Generates an underground terrain obstacle.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// An underground tile.
        /// </returns>
        public static GameEntityBase MakeUnderground(ContentProvider contentProvider, Point position)
        {
            var texture = contentProvider.GetTerrainTexture(null);
            
            return TerrainEntity.CreateSoil(texture, position);
        }
    }
}
