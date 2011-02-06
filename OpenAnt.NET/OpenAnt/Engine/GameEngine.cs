using System.Collections.Generic;
using OpenAnt.Helper;

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
            this.canvas.DrawSprites(spriteBatch, this.worldData.CpuSpriteData);
            this.canvas.DrawOverlay(spriteBatch);
        }

        public void MovePlayer(int deltaX, int deltaY)
        {
            this.MoveSprite(this.worldData.Player, deltaX, deltaY);

            // centralize viewport on player
            this.canvas.CentralizeViewport((int)this.worldData.Player.Position.X, (int)this.worldData.Player.Position.Y);
        }

        public void Interact()
        {
            // TODO this shouldn't be here, since cpu-ants can't access stuff here...
            var newPosition = this.worldData.Player.Position.Location;
            var delta = OrientationHelper.GetAdjacentPointDelta(this.worldData.Player.FacingDirection);
            newPosition.X += delta.X;
            newPosition.Y += delta.Y;

            var collisionTile = this.worldData.SpriteData.FirstOrDefault(w => w.IsHitTestCollision(newPosition)); // FIXME SingleOrDefault/FirstOrDefault = bad
            if (collisionTile != null)
            {
                if (this.worldData.Player.HoldingEntity == null)
                {
                    this.worldData.Player.InteractWith(collisionTile);

                    // NOTE this is really an underworld thing...
                    this.worldData.SpriteData.Remove(collisionTile);
                }
            }
            else
            {
                // put the thing down
                if (this.worldData.Player.HoldingEntity != null)
                {
                    var placedEntity = this.worldData.Player.HoldingEntity;
                    var pos = placedEntity.Position;
                    pos.Location = newPosition;
                    placedEntity.Position = pos;

                    // fix the world map
                    this.worldData.SpriteData.Add(placedEntity);
                    this.worldData.Player.HoldingEntity = null;
                }
            }
        }

        public void Update()
        {
            this.worldData.CpuSpriteData.ForEach(o =>
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

            // TODO update direction facing
            sprite.FacingDirection = OrientationHelper.GetFacingDirection(sprite.Position.Location, newPosition);
            
            // edge of the world blocks
            if (!this.worldData.Boundary.Contains(newPosition))
            {
                return;
            }

            // TODO uncrashable collision detection and decision
            bool doMove = true;
            var collisionTile = this.worldData.SpriteData.FirstOrDefault(w => w.IsHitTestCollision(newPosition)); // FIXME SingleOrDefault/FirstOrDefault = bad
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
