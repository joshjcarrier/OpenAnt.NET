namespace OpenAnt.Generator
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Engine;
    using Entity;
    using Entity.Sprite;
    using World;

    /// <summary>
    /// Generates random terrain for an underground world.
    /// </summary>
    public static class UndergroundGenerator
    {
        /// <summary>
        /// Generates a random underground world.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        /// <param name="notifyWorldChangeRequested">
        /// The notify world change requested.
        /// </param>
        /// <returns>
        /// A random underground world.
        /// </returns>
        public static WorldData Make(ContentProvider contentProvider, INotifyWorldChangeRequested notifyWorldChangeRequested)
        {
            var boundary = new Rectangle(0, 0, 40, 30);

            var surfaceData = new List<GameEntityBase>();

            // depth
            // NOTE underworld generator doesn't generate top 2 rows
            for (var i = boundary.Top + 2; i < boundary.Height; i++)
            {
                // breadth
                for (var j = boundary.Left; j < boundary.Width; j++)
                {
                    surfaceData.Add(TerrainGenerator.MakeSurface(contentProvider, new Point(j, i)));
                }
            }

            var player = YellowAntEntity.Create(contentProvider, new Point(5, 1), notifyWorldChangeRequested);

            var spriteData = new List<GameEntityBase> { player };

            var cpuSpriteData = new List<GameEntityBase>();

            return new WorldData(surfaceData, spriteData, cpuSpriteData, player, boundary);
        }
    }
}
