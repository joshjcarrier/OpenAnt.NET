using Microsoft.Xna.Framework;

namespace OpenAnt
{
    using System.Collections.Generic;
    using Entity;

    /// <summary>
    /// Encapsulates all world data.
    /// </summary>
    public class WorldData
    {
        public WorldData(IList<GameEntity> surfaceData, IList<GameEntity> spriteData, GameEntity player, Rectangle boundary)
        {
            this.SurfaceData = surfaceData;
            this.SpriteData = spriteData;
            this.Player = player;
            this.Boundary = boundary;
        }

        /// <summary>
        /// Surface data.
        /// </summary>
        public IList<GameEntity> SurfaceData;

        /// <summary>
        /// Collidable objects data.
        /// </summary>
        public IList<GameEntity> SpriteData;

        public GameEntity Player;

        public Rectangle Boundary { get; private set; }
    }
}
