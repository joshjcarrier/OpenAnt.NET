using OpenAnt.Generator;

namespace OpenAnt.Engine
{
    using Canvas;

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
        /// <param name="worldData">
        /// The world data.
        /// </param>
        protected OverworldGameEngine(EagleEyeWorldCanvas canvas, WorldData worldData) : base(canvas, worldData)
        {
        }

        public static GameEngine Create(ContentProvider contentProvider)
        {
            var worldData = OverworldGenerator.Make(contentProvider);
            return new OverworldGameEngine(new OverworldEagleEyeWorldCanvas(contentProvider, worldData.Boundary), worldData);
        }
    }
}
