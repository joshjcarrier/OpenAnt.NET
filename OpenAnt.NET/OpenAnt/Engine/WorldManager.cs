namespace OpenAnt.Engine
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Data;
    using Entity;
    using Generator;
    using Helper;
    using World;

    /// <summary>
    /// Handles transactions in the world, in-memory.
    /// </summary>
    public class WorldManager : IWorldManager
    {
        /// <summary>
        /// The surface world data.
        /// </summary>
        private readonly IList<WorldData> surfaceWorld;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldManager"/> class.
        /// </summary>
        public WorldManager()
        {
            // TODO fix dependency this.World = OverworldGenerator.Make(contentProvider, this); // TODO this would be loaded from somewhere
            this.surfaceWorld = OverworldGenerator.Make().ToList();
            this.Player = new WorldData { Position = new Point(0, 0), Type = EntityType.Ant };
            this.surfaceWorld.Add(this.Player);
        }

        /// <summary>
        /// Gets SurfaceWorld data for the current game.
        /// </summary>
        public IEnumerable<WorldData> SurfaceWorld
        {
            get { return this.surfaceWorld; }
        }

        /// <summary>
        /// Gets Player.
        /// </summary>
        /// <remarks>
        /// NOTE temporary.
        /// </remarks>
        public WorldData Player { get; private set; }

        /// <summary>
        /// Updates the world manager.
        /// </summary>
        public void Update()
        {
            // TODO run through game logic, AI here
            // TODO this goes to the world manager
            // this.worldManager.World.CpuSpriteData.ForEach(o => o.UpdateAwareness());

            // calculate and update statistics to be displayed on canvas
            // var yellowAntHealth = this.worldManager.World.Player.Health;
            // var blackColonyHealth = this.worldManager.World.SpriteData.Where(o => o.Allegiance == Player.Black).Average(o => o.Health);

            // var redColonyHealth = this.WorldManager.World.SpriteData.Where(o => o.Allegiance == Player.Red).Average(o => o.Health);
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
        /// <remarks>
        /// TODO needs to support player index.
        /// </remarks>
        public void PlayerMoveRequest(int deltaX, int deltaY)
        {
            var newPosition = this.Player.Position;
            newPosition.X += deltaX;
            newPosition.Y += deltaY;
            
            // TODO should allow some sort of decorated move logic
            this.Player.Position = newPosition;
            //// this.Player.Move(newPosition);
        }

        /// <summary>
        /// Performs a player interaction.
        /// </summary>
        public void Interact()
        {
            ////var newPosition = this.Player.Position;
            ////var delta = OrientationHelper.GetAdjacentPointDelta(this.Player.FacingDirection);
            ////newPosition.X += delta.X;
            ////newPosition.Y += delta.Y;
            //// this.Player.InteractWith(newPosition);
        }

        /// <summary>
        /// Checks for collisions at the given point in the world.
        /// </summary>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <returns>
        /// Gets the collidable entity at given location.
        /// </returns>
        public GameEntityBase GetEntityAt(Point location)
        {
            // TODO is hit test collision check necessary?
            return null; // this.SpriteData.FirstOrDefault(w => w.IsHitTestCollision(location)); // FIXME SingleOrDefault/FirstOrDefault = bad
        }

        /// <summary>
        /// Responds to a world change request.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="targetLocation">
        /// The target location.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        public void OnNotifyWorldChangeRequested(GameEntityBase sender, Point targetLocation, object action)
        {
            var actionType = (ActionType)action;

            switch (actionType)
            {
                case ActionType.PrecisionMove:
                    this.MoveEntity(sender, targetLocation, true);
                    break;
                case ActionType.Move:
                    this.MoveEntity(sender, targetLocation, false);
                    break;
                case ActionType.Interact:
                    this.Interact(sender, targetLocation);
                    break;
            }
        }

        /// <summary>
        /// Performs an interaction operation on the target location.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="targetLocation">
        /// The target location.
        /// </param>
        private void Interact(GameEntityBase sender, Point targetLocation)
        {
            // TODO use targetLocation for cpu ants?
            var newPosition = sender.Position.Location;
            var delta = OrientationHelper.GetAdjacentPointDelta(sender.FacingDirection);
            newPosition.X += delta.X;
            newPosition.Y += delta.Y;

            var collisionTile = this.GetEntityAt(newPosition);

            // TODO somehow determine if this is pick up logic or something else
            if (collisionTile != null)
            {
                if (sender.HoldingEntity == null)
                {
                    sender.HoldingEntity = collisionTile;

                    // NOTE this is really an underworld thing...
                    // this.SpriteData.Remove(collisionTile);
                }
            }
            else
            {
                // put the thing down
                if (sender.HoldingEntity != null)
                {
                    var placedEntity = sender.HoldingEntity;
                    var pos = placedEntity.Position;
                    pos.Location = newPosition;
                    placedEntity.Position = pos;

                    // fix the world map
                    // this.SpriteData.Add(placedEntity);
                    sender.HoldingEntity = null;
                }
            }
        }

        /// <summary>
        /// Perform a move operation on the entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="targetLocation">
        /// The target location.
        /// </param>
        /// <param name="isPrecisionMove">
        /// The is precision move.
        /// </param>
        private void MoveEntity(GameEntityBase entity, Point targetLocation, bool isPrecisionMove)
        {
            var oldPosition = entity.Position.Location;
            var newOrientation = OrientationHelper.GetFacingDirection(oldPosition, targetLocation);
            
            // face the direction
            var oldOrientation = entity.FacingDirection;
            entity.FacingDirection = newOrientation;
            
            // edge of the world blocks
            // if (!this.Boundary.Contains(targetLocation))
            // {
            //    return;
            // }

            // TODO uncrashable collision detection and decision
            var doMove = true;
            /*
            var collisionTile = this.SpriteData.FirstOrDefault(w => w.IsHitTestCollision(targetLocation)); // FIXME SingleOrDefault/FirstOrDefault = bad
            if (collisionTile != null)
            {
                doMove = collisionTile.CollideOn(entity);

                // NOTE this is what digging does - really an underworld interaction...
                // SurfaceData.Remove(collisionTile);
            }
             * */

            // move the sprite, performing neighbour tile updates as necessary
            if (doMove)
            {
                // TODO update neighboring tiles?
                if (isPrecisionMove)
                {
                    if (newOrientation == oldOrientation)
                    {
                        var rect = entity.Position;
                        rect.Location = targetLocation;
                        entity.Position = rect;
                        entity.Health -= 1;
                    }
                }
                else
                {
                    var rect = entity.Position;
                    rect.Location = targetLocation;
                    entity.Position = rect;
                    entity.Health -= 1;
                }
            }
        }
    }
}
