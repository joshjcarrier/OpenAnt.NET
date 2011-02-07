namespace OpenAnt.World
{
    using Microsoft.Xna.Framework;
    using Entity;

    /// <summary>
    /// The world manager, which handles transactions in the world.
    /// </summary>
    public interface IWorldManager : INotifyWorldChangeRequested
    {
        /// <summary>
        /// Gets or sets World.
        /// </summary>
        /// <remarks>
        /// Setting the world in the future should not be allowed externally.
        /// </remarks>
        WorldData World { get; set; }

        /// <summary>
        /// Gets the collidable entity at the given location.
        /// </summary>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <returns>
        /// The collidable entity at the location.
        /// </returns>
        GameEntityBase GetEntityAt(Point location);
    }
}