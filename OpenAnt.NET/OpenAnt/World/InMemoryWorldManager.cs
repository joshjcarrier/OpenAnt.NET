namespace OpenAnt.World
{
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Entity;
    using Helper;

    /// <summary>
    /// Handles transactions in the world, in-memory.
    /// </summary>
    public class InMemoryWorldManager : IWorldManager
    {
        public InMemoryWorldManager(ContentProvider contentProvider)
        {
            // TODO fix dependency this.World = OverworldGenerator.Make(contentProvider, this); // TODO this would be loaded from somewhere
        }

        public WorldData World { get; set; }

        public GameEntityBase GetEntityAt(Point location)
        {
            // TODO is hit test collision check necessary?
            return this.World.SpriteData.FirstOrDefault(w => w.IsHitTestCollision(location)); // FIXME SingleOrDefault/FirstOrDefault = bad
        }

        public void OnNotifyWorldChangeRequested(GameEntityBase sender, Point targetLocation, object action)
        {
            ActionType actionType = (ActionType) action;

            switch(actionType)
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
                    this.World.SpriteData.Remove(collisionTile);
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
                    this.World.SpriteData.Add(placedEntity);
                    sender.HoldingEntity = null;
                }
            }
        }

        private void MoveEntity(GameEntityBase entity, Point targetLocation, bool isPrecisionMove)
        {
            var oldPosition = entity.Position.Location;
            var newOrientation = OrientationHelper.GetFacingDirection(oldPosition, targetLocation);
            
            // face the direction
            var oldOrientation = entity.FacingDirection;
            entity.FacingDirection = newOrientation;
            
            // edge of the world blocks
            if (!this.World.Boundary.Contains(targetLocation))
            {
                return;
            }

            // TODO uncrashable collision detection and decision
            bool doMove = true;
            var collisionTile = this.World.SpriteData.FirstOrDefault(w => w.IsHitTestCollision(targetLocation)); // FIXME SingleOrDefault/FirstOrDefault = bad
            if (collisionTile != null)
            {
                doMove = collisionTile.CollideOn(entity);

                // NOTE this is what digging does - really an underworld interaction...
                // SurfaceData.Remove(collisionTile);
            }

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
