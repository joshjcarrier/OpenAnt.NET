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
        private EagleEyeWorldCanvas canvas;
        protected IWorldManager WorldManager;

        protected GameEngine(EagleEyeWorldCanvas canvas, IWorldManager worldManager)
        {
            this.canvas = canvas;
            this.WorldManager = worldManager;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //ViewportHelper.CurrentDevice.Viewport = ViewportHelper.DefaultViewport;
            spriteBatch.Begin();
            ViewportHelper.CurrentDevice.Viewport = ViewportHelper.SpriteViewport;
            this.canvas.DrawUnderlay(spriteBatch);
            this.canvas.DrawSprites(spriteBatch, this.WorldManager.World.SurfaceData);
            this.canvas.DrawSprites(spriteBatch, this.WorldManager.World.SpriteData);
            this.canvas.DrawSprites(spriteBatch, this.WorldManager.World.CpuSpriteData);
            spriteBatch.End();

            spriteBatch.Begin();
            ViewportHelper.CurrentDevice.Viewport = ViewportHelper.MenuViewport;
            this.canvas.DrawOverlay(spriteBatch);
            spriteBatch.End();
        }

        public void MovePlayer(int deltaX, int deltaY)
        {
            var newPosition = this.WorldManager.World.Player.Position.Location;
            newPosition.X += deltaX;
            newPosition.Y += deltaY;
            this.WorldManager.World.Player.Move(newPosition);

            // centralize viewport on player);
            this.canvas.CentralizeViewport((int)this.WorldManager.World.Player.Position.X, (int)this.WorldManager.World.Player.Position.Y);
        }

        public void Interact()
        {
            var newPosition = this.WorldManager.World.Player.Position.Location;
            var delta = OrientationHelper.GetAdjacentPointDelta(this.WorldManager.World.Player.FacingDirection);
            newPosition.X += delta.X;
            newPosition.Y += delta.Y;
            this.WorldManager.World.Player.InteractWith(newPosition);
        }

        public void Update()
        {
            this.WorldManager.World.CpuSpriteData.ForEach(o => o.UpdateAwareness());

            // calculate and update statistics to be displayed on canvas
            var yellowAntHealth = this.WorldManager.World.Player.Health;
            var blackColonyHealth = this.WorldManager.World.SpriteData.Where(o => o.Allegiance == Player.Black).Average(o => o.Health);
            // var redColonyHealth = this.WorldManager.World.SpriteData.Where(o => o.Allegiance == Player.Red).Average(o => o.Health);
        }
    }
}
