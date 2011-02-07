namespace OpenAnt.Engine
{
    using System.Linq;
    using Microsoft.Xna.Framework.Graphics;
    using Canvas;
    using Helper;
    using World;

    /// <summary>
    /// Handles player logic, movement.
    /// </summary>
    public abstract class GameEngine
    {
        /// <summary>
        /// The canvas to draw to.
        /// </summary>
        private readonly EagleEyeWorldCanvas canvas;

        /// <summary>
        /// The world manager co-ordinating world updates.
        /// </summary>
        private readonly IWorldManager worldManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine"/> class.
        /// </summary>
        /// <param name="canvas">
        /// The canvas.
        /// </param>
        /// <param name="worldManager">
        /// The world manager.
        /// </param>
        /// <remarks>
        /// NOTE the canvas can be extracted.
        /// </remarks>
        protected GameEngine(EagleEyeWorldCanvas canvas, IWorldManager worldManager)
        {
            this.canvas = canvas;
            this.worldManager = worldManager;
        }

        /// <summary>
        /// Draws graphical artifacts using the canvas.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            ViewportHelper.CurrentDevice.Viewport = ViewportHelper.SpriteViewport;
            this.canvas.DrawUnderlay(spriteBatch);
            this.canvas.DrawSprites(spriteBatch, this.worldManager.World.SurfaceData);
            this.canvas.DrawSprites(spriteBatch, this.worldManager.World.SpriteData);
            this.canvas.DrawSprites(spriteBatch, this.worldManager.World.CpuSpriteData);
            spriteBatch.End();

            spriteBatch.Begin();
            ViewportHelper.CurrentDevice.Viewport = ViewportHelper.MenuViewport;
            this.canvas.DrawOverlay(spriteBatch);
            spriteBatch.End();
        }

        /// <summary>
        /// Process to move the player.
        /// </summary>
        /// <param name="deltaX">
        /// The delta x.
        /// </param>
        /// <param name="deltaY">
        /// The delta y.
        /// </param>
        public void MovePlayer(int deltaX, int deltaY)
        {
            var newPosition = this.worldManager.World.Player.Position.Location;
            newPosition.X += deltaX;
            newPosition.Y += deltaY;
            this.worldManager.World.Player.Move(newPosition);

            // centralize viewport on player);
            this.canvas.CentralizeViewport(this.worldManager.World.Player.Position.X, this.worldManager.World.Player.Position.Y);
        }

        /// <summary>
        /// Performs a player interaction.
        /// </summary>
        public void Interact()
        {
            var newPosition = this.worldManager.World.Player.Position.Location;
            var delta = OrientationHelper.GetAdjacentPointDelta(this.worldManager.World.Player.FacingDirection);
            newPosition.X += delta.X;
            newPosition.Y += delta.Y;
            this.worldManager.World.Player.InteractWith(newPosition);
        }

        /// <summary>
        /// Runs engine updates.
        /// </summary>
        public void Update()
        {
            this.worldManager.World.CpuSpriteData.ForEach(o => o.UpdateAwareness());

            // calculate and update statistics to be displayed on canvas
            var yellowAntHealth = this.worldManager.World.Player.Health;
            var blackColonyHealth = this.worldManager.World.SpriteData.Where(o => o.Allegiance == Player.Black).Average(o => o.Health);

            // var redColonyHealth = this.WorldManager.World.SpriteData.Where(o => o.Allegiance == Player.Red).Average(o => o.Health);
        }
    }
}
