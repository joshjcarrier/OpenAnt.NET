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
        public WorldData(IList<GameEntityBase> surfaceData, IList<GameEntityBase> spriteData, GameEntityBase player, Rectangle boundary)
        {
            this.SurfaceData = surfaceData;
            this.SpriteData = spriteData;
            this.Player = player;
            this.Boundary = boundary;
        }

        /// <summary>
        /// Surface data.
        /// </summary>
        public IList<GameEntityBase> SurfaceData;

        /// <summary>
        /// Collidable objects data.
        /// </summary>
        public IList<GameEntityBase> SpriteData;

        public GameEntityBase Player;

        public Rectangle Boundary { get; private set; }
    }
}
