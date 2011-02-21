namespace OpenAnt.Generator
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Data;

    /// <summary>
    /// Generates an overworld map.
    /// </summary>
    public static class OverworldGenerator
    {
        /// <summary>
        /// Generates a new random overworld map.
        /// </summary>
        /// <returns>
        /// A new random overworld.
        /// </returns>
        public static IEnumerable<WorldData> Make()
        {
            var boundary = new Rectangle(0, 0, 40, 30);

            var surfaceData = new List<WorldData>();

            // depth
            // NOTE underworld generator doesn't generate top 2 rows
            for (var i = boundary.Top; i < boundary.Height; i++)
            {
                // breadth
                for (var j = boundary.Left; j < boundary.Width; j++)
                {
                    surfaceData.Add(TerrainGenerator.MakeSurface(new Point(j, i)));
                }
            }

            var r = new Random();
            for (var x = 0; x < 20; x++)
            {
                surfaceData.Add(
                    TerrainGenerator.MakeObstacle(
                    new Point(r.Next(boundary.Left, boundary.Width), r.Next(boundary.Top, boundary.Height))));
            }

            return surfaceData;
        }
    }
}
