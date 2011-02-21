namespace OpenAnt.Generator
{
    using System;
    using Microsoft.Xna.Framework;
    using Data;
    using Entity;

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
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// A random surface terrain.
        /// </returns>
        public static WorldData MakeSurface(Point position)
        {
            var thing = RandomGen.Next(0, 100);
            string subtype;
            if (thing > 98)
            {
                subtype = TerrainResource.Ground4;
            }
            else if (thing > 35)
            {
                subtype = TerrainResource.Ground1;
            }
            else if (thing > 25)
            {
                subtype = TerrainResource.Ground2;
            }
            else if (thing > 13)
            {
                subtype = TerrainResource.Ground3;
            }
            else if (thing > 8)
            {
                subtype = TerrainResource.Foliage1;
            }
            else if (thing > 3)
            {
                subtype = TerrainResource.Foliage2;
            }
            else
            {
                subtype = TerrainResource.Foliage3;
            }

            return new WorldData { Position = position, Subtype = subtype, Type = EntityType.TerrainSurface, Size = 1 };
        }

        /// <summary>
        /// Generates a random terrain obstacle.
        /// </summary>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// A random terrain obstacle.
        /// </returns>
        public static WorldData MakeObstacle(Point position)
        {
            var thing = RandomGen.Next(0, 100);
            string subtype;
            int size = 1;
            if (thing > 92)
            {
                subtype = TerrainResource.GroundRock4;
                size = 2;
            }
            else if (thing > 80)
            {
                subtype = TerrainResource.Rock1;
            }
            else if (thing > 35)
            {
                subtype = TerrainResource.Rock2;
            }
            else
            {
                subtype = TerrainResource.Rock3;
            }

            return new WorldData { Position = position, Subtype = subtype, Type = EntityType.TerrainObstacle, Size = size };
        }
    }
}
