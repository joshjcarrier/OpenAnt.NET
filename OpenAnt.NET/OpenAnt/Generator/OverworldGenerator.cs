namespace OpenAnt.Generator
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Entity;
    using Entity.Sprite;
    using Engine;
    using World;

    public class OverworldGenerator
    {
        public static WorldData Make(ContentProvider contentProvider, INotifyWorldChangeRequested notifyWorldChangeRequested)
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

            var Player = YellowAntEntity.Create(contentProvider, new Point(5, 1), notifyWorldChangeRequested);

            var SpriteData = new List<GameEntityBase>();
            var r = new Random();
            for (var x = 0; x < 20; x++)
            {
                SpriteData.Add(TerrainGenerator.MakeObstacle(contentProvider, new Point(r.Next(boundary.Left, boundary.Width), r.Next(boundary.Top, boundary.Height))));
            }

            var CpuSpriteData = new List<GameEntityBase>();
            for (var x = 0; x < 10; x++)
            {
                var entity = AntEntity.Create(contentProvider, new Point(r.Next(boundary.Left, boundary.Width), r.Next(boundary.Top, boundary.Height)), notifyWorldChangeRequested);
                CpuSpriteData.Add(entity);
            }

            SpriteData.Add(Player);

            return new WorldData(SurfaceData, SpriteData, CpuSpriteData, Player, boundary);
        }
    }
}
