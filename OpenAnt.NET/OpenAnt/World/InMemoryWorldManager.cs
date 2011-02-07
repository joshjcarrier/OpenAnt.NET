namespace OpenAnt.World
{
    using Microsoft.Xna.Framework;
    using Entity;
    using Generator;

    /// <summary>
    /// Handles transactions in the world, in-memory.
    /// </summary>
    public class InMemoryWorldManager : IWorldManager
    {
        public InMemoryWorldManager(ContentProvider contentProvider)
        {
            this.World = OverworldGenerator.Make(contentProvider, this); // TODO this would be loaded from somewhere
        }

        public WorldData World { get; set; }

        public void OnNotifyWorldChangeRequested(GameEntityBase sender, Point targetLocation, object action)
        {
            return;
        }
    }
}
