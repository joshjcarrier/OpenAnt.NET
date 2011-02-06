using OpenAnt.Engine;

namespace OpenAnt.Generator
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Entity;
    using Entity.Sprite;
    using Entity.Terrain;

    public class OverworldGenerator
    {
        public static WorldData Make(ContentProvider contentProvider)
        {
            var boundary = new Rectangle(0, 0, 40, 30);

            var SurfaceData = new List<GameEntityBase>();

            // depth
            // NOTE underworld generator doesn't generate top 2 rows
            for (var i = boundary.Top; i < boundary.Height; i++)
            {
                // breadth
                for (var j = boundary.Left; j < boundary.Width; j++)
                {
                    SurfaceData.Add(TerrainGenerator.MakeSurface(contentProvider, new Point(j, i)));
                }
            }

            var Player = YellowAntEntity.Create(contentProvider, new Point(5, 1));

            var SpriteData = new List<GameEntityBase>();
            var r = new Random();
            for (var x = 0; x < 20; x++)
            {
                SpriteData.Add(TerrainGenerator.MakeObstacle(contentProvider, new Point(r.Next(boundary.Left, boundary.Width), r.Next(boundary.Top, boundary.Height))));
            }

            SpriteData.Add(Player);

            return new WorldData(SurfaceData, SpriteData, Player, boundary);
        }
    }
}
