using OpenAnt.Generator;
using OpenAnt.World;

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
        protected OverworldGameEngine(EagleEyeWorldCanvas canvas, IWorldManager worldManager) : base(canvas, worldManager)
        {
        }

        public static GameEngine Create(ContentProvider contentProvider, IWorldManager worldManager)
        {
            return new OverworldGameEngine(new OverworldEagleEyeWorldCanvas(contentProvider, worldManager.World.Boundary), worldManager);
        }
    }
}
