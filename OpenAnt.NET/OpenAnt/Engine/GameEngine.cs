namespace OpenAnt.Engine
{
    using System.Linq;
    using Microsoft.Xna.Framework.Graphics;
    using Canvas;
    using Entity;

    /// <summary>
    /// Handles player logic, movement.
    /// </summary>
    public abstract class GameEngine
    {
        private EagleEyeWorldCanvas canvas;
        protected WorldData worldData;
        
        protected GameEngine(EagleEyeWorldCanvas canvas, WorldData worldData)
        {
            this.canvas = canvas;
            this.worldData = worldData;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.canvas.DrawUnderlay(spriteBatch);
            this.canvas.DrawSprites(spriteBatch, this.worldData.SurfaceData);
            this.canvas.DrawSprites(spriteBatch, this.worldData.SpriteData);
            this.canvas.DrawOverlay(spriteBatch);
        }

        public void MovePlayer(int deltaX, int deltaY)
        {
            this.MoveSprite(this.worldData.Player, deltaX, deltaY);

            // centralize viewport on player
            this.canvas.CentralizeViewport((int)this.worldData.Player.Position.X, (int)this.worldData.Player.Position.Y);
        }

        private void MoveSprite(GameEntity sprite, int deltaX, int deltaY)
        {
            // estimated position
            var newPosition = sprite.Position.Location;
            newPosition.X += deltaX;
            newPosition.Y += deltaY;
            
            // edge of the world blocks
            if (!this.worldData.Boundary.Contains(newPosition))
            {
                return;
            }

            // TODO uncrashable collision detection and decision
            bool doMove = true;
            var collisionTile = this.worldData.SpriteData.SingleOrDefault(w => w.IsHitTestCollision(newPosition)); // FIXME SingleOrDefault = bad
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
