namespace OpenAnt.Screen
{
    using Microsoft.Xna.Framework;
    using Engine;

    /// <summary>
    /// Game processing when underground.
    /// </summary>
    public class UndergroundScreen : EagleEyeScreenBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UndergroundScreen"/> class.
        /// </summary>
        /// <param name="worldManager">
        /// The world manager.
        /// </param>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        /// <param name="worldBoundary">
        /// The world boundary.
        /// </param>
        public UndergroundScreen(IWorldManager worldManager, ContentProvider contentProvider, Rectangle worldBoundary) : base(worldManager, contentProvider, worldBoundary)
        {
        }
    }
}
