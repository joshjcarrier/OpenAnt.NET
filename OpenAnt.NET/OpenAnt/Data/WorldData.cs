namespace OpenAnt.Data
{
    using Microsoft.Xna.Framework;
    using Entity;

    /// <summary>
    /// Represents a stateful entity in the world.
    /// </summary>
    public class WorldData
    {
        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        public EntityType Type { get; set; }

        /// <summary>
        /// Gets or sets Subtype.
        /// </summary>
        public string Subtype { get; set; }

        /// <summary>
        /// Gets or sets Position.
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// Gets or sets Size.
        /// </summary>
        public int Size { get; set; }
    }
}
