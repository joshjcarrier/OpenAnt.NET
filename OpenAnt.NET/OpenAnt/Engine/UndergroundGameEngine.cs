namespace OpenAnt.Engine
{
    using Canvas;
    using Generator;

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
        /// <param name="worldData">
        /// The world data.
        /// </param>
        public UndergroundGameEngine(EagleEyeWorldCanvas canvas, WorldData worldData) : base(canvas, worldData)
        {
        }

        public static GameEngine Create(ContentProvider contentProvider)
        {
            // TODO this should be underworld
            var worldData = OverworldGenerator.Make(contentProvider);
            return new UndergroundGameEngine(new UndergroundEagleEyeWorldCanvas(contentProvider, worldData.Boundary), worldData);
        }
    }
}
