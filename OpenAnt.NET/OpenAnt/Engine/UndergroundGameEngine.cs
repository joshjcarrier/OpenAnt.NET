namespace OpenAnt.Engine
{
    using Canvas;
    using Generator;
    using World;

    /// <summary>
    /// Game processing when underground.
    /// </summary>
    public class UndergroundGameEngine : GameEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UndergroundGameEngine"/> class.
        /// </summary>
        /// <param name="canvas">
        /// The canvas.
        /// </param>
        /// <param name="worldManager">
        /// The world Manager.
        /// </param>
        public UndergroundGameEngine(EagleEyeWorldCanvas canvas, IWorldManager worldManager) : base(canvas, worldManager)
        {
        }

        /// <summary>
        /// Creates an underground game engine.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        /// <param name="worldManager">
        /// The world manager.
        /// </param>
        /// <returns>
        /// An underground game engine.
        /// </returns>
        public static GameEngine Create(ContentProvider contentProvider, IWorldManager worldManager)
        {
            var worldData = UndergroundGenerator.Make(contentProvider, worldManager);
            worldManager.World = worldData;
            return new UndergroundGameEngine(new UndergroundEagleEyeWorldCanvas(contentProvider, worldData.Boundary), worldManager);
        }
    }
}
