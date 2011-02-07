namespace OpenAnt.Engine
{
    using System.Linq;
    using Microsoft.Xna.Framework.Graphics;
    using Canvas;
    using Entity;
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
            this.canvas.DrawUnderlay(spriteBatch);
            this.canvas.DrawSprites(spriteBatch, this.WorldManager.World.SurfaceData);
            this.canvas.DrawSprites(spriteBatch, this.WorldManager.World.SpriteData);
            this.canvas.DrawSprites(spriteBatch, this.WorldManager.World.CpuSpriteData);
            this.canvas.DrawOverlay(spriteBatch);
        }

        public void MovePlayer(int deltaX, int deltaY)
        {
            this.MoveSprite(this.WorldManager.World.Player, deltaX, deltaY);

            // centralize viewport on player
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
            this.WorldManager.World.CpuSpriteData.ForEach(o =>
            {
                var point = o.UpdateAwareness();
                MoveSprite(o, point.X, point.Y);
            });
        }

        private void MoveSprite(GameEntityBase sprite, int deltaX, int deltaY)
        {
            // estimated position
            var newPosition = sprite.Position.Location;
            newPosition.X += deltaX;
            newPosition.Y += deltaY;

            // edge of the world blocks
            if (!this.WorldManager.World.Boundary.Contains(newPosition))
            {
                return;
            }

            // TODO uncrashable collision detection and decision
            bool doMove = true;
            var collisionTile = this.WorldManager.World.SpriteData.FirstOrDefault(w => w.IsHitTestCollision(newPosition)); // FIXME SingleOrDefault/FirstOrDefault = bad
            if (collisionTile != null)
            {
                doMove = collisionTile.CollideOn(sprite);

                // NOTE this is really an underworld thing...
                // SurfaceData.Remove(collisionTile);
            }

            // move the sprite, performing neighbour tile updates as necessary
            if (doMove)
            {
                // TODO update neighboring tiles?
                sprite.Move(newPosition);    
            }
        }
    }
}
