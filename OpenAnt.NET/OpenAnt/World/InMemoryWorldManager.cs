using OpenAnt.Entity;
using OpenAnt.Generator;

namespace OpenAnt.World
{
    using Microsoft.Xna.Framework;

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

        public void OnNotifyWorldChangeRequested(InteractableGameEntityBase sender, Point targetLocation, object action)
        {
            return;
        }
    }
}
