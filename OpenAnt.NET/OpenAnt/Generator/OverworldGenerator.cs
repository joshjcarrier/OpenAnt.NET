namespace OpenAnt.Generator
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Entity;
    using Entity.Sprite;
    using Engine;
    using World;

    /// <summary>
    /// Generates an overworld map.
    /// </summary>
    public static class OverworldGenerator
    {
        /// <summary>
        /// Generates a new random overworld map.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        /// <param name="notifyWorldChangeRequested">
        /// The notify world change requested.
        /// </param>
        /// <returns>
        /// A new random overworld.
        /// </returns>
        public static WorldData Make(ContentProvider contentProvider, INotifyWorldChangeRequested notifyWorldChangeRequested)
        {
            var boundary = new Rectangle(0, 0, 40, 30);

            var surfaceData = new List<GameEntityBase>();

            // depth
            // NOTE underworld generator doesn't generate top 2 rows
            for (var i = boundary.Top; i < boundary.Height; i++)
            {
                // breadth
                for (var j = boundary.Left; j < boundary.Width; j++)
                {
                    surfaceData.Add(TerrainGenerator.MakeSurface(contentProvider, new Point(j, i)));
                }
            }

            var player = YellowAntEntity.Create(contentProvider, new Point(5, 1), notifyWorldChangeRequested);

            var spriteData = new List<GameEntityBase>();
            var r = new Random();
            for (var x = 0; x < 20; x++)
            {
                spriteData.Add(TerrainGenerator.MakeObstacle(contentProvider, new Point(r.Next(boundary.Left, boundary.Width), r.Next(boundary.Top, boundary.Height))));
            }

            var cpuSpriteData = new List<GameEntityBase>();
            for (var x = 0; x < 10; x++)
            {
                var entity = AntEntity.Create(contentProvider, new Point(r.Next(boundary.Left, boundary.Width), r.Next(boundary.Top, boundary.Height)), notifyWorldChangeRequested);
                cpuSpriteData.Add(entity);
            }

            spriteData.Add(player);

            spriteData.Add(FoodEntity.Create(contentProvider, new Point(10, 10)));
            return new WorldData(surfaceData, spriteData, cpuSpriteData, player, boundary);
        }
    }
}
