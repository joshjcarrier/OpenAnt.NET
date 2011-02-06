namespace OpenAnt
{
    using System.Collections.Generic;
    using Entity;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Encapsulates all world data.
    /// </summary>
    public class WorldData
    {
        public WorldData(IList<GameEntityBase> surfaceData, IList<GameEntityBase> spriteData, IList<GameEntityBase> cpuSpriteData, GameEntityBase player, Rectangle boundary)
        {
            this.SurfaceData = surfaceData;
            this.SpriteData = spriteData;
            this.CpuSpriteData = cpuSpriteData;
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

        /// <summary>
        /// Entities controlled by the CPU.
        /// </summary>
        public IList<GameEntityBase> CpuSpriteData;

        public GameEntityBase Player;

        public Rectangle Boundary { get; private set; }
    }
}
