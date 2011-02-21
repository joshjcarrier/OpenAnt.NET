namespace OpenAnt.Screen
{
    using Microsoft.Xna.Framework;
    using Engine;

    /// <summary>
    /// Game rendering logic in the overworld.
    /// </summary>
    public class OverworldScreen : EagleEyeScreenBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OverworldScreen"/> class.
        /// </summary>
        /// <param name="worldManager">
        /// The world Manager.
        /// </param>
        /// <param name="contentProvider">
        /// The content Provider.
        /// </param>
        /// <param name="worldBoundary">
        /// The world Boundary.
        /// </param>
        public OverworldScreen(IWorldManager worldManager, ContentProvider contentProvider, Rectangle worldBoundary)
            : base(worldManager, contentProvider, worldBoundary)
        {
        }
    }
}
