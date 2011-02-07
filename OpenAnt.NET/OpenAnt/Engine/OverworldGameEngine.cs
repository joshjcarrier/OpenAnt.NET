namespace OpenAnt.Engine
{
    using Canvas;
    using Generator;
    using World;

    /// <summary>
    /// Game processing logic in the overworld.
    /// </summary>
    public class OverworldGameEngine : GameEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OverworldGameEngine"/> class.
        /// </summary>
        /// <param name="canvas">
        /// The canvas.
        /// </param>
        /// <param name="worldManager">
        /// The world Manager.
        /// </param>
        protected OverworldGameEngine(EagleEyeWorldCanvas canvas, IWorldManager worldManager) : base(canvas, worldManager)
        {
        }

        /// <summary>
        /// Creates a new Overworld game engine.
        /// </summary>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        /// <param name="worldManager">
        /// The world manager.
        /// </param>
        /// <returns>
        /// A new Overworld game engine.
        /// </returns>
        public static GameEngine Create(ContentProvider contentProvider, IWorldManager worldManager)
        {
            var worldData = OverworldGenerator.Make(contentProvider, worldManager);
            worldManager.World = worldData;
            return new OverworldGameEngine(new OverworldEagleEyeWorldCanvas(contentProvider, worldData.Boundary), worldManager);
        }
    }
}
