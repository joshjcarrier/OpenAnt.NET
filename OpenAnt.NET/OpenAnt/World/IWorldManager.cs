namespace OpenAnt.World
{
    public interface IWorldManager : INotifyWorldChangeRequested
    {
        /// <summary>
        /// Gets or sets World.
        /// </summary>
        /// <remarks>
        /// Setting the world in the future should not be allowed externally.
        /// </remarks>
        WorldData World { get; set; }
    }
}