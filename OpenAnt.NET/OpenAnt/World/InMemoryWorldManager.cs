using System.Linq;

namespace OpenAnt.World
{
    using Microsoft.Xna.Framework;
    using Entity;
    using Helper;
    using Generator;

    /// <summary>
    /// Handles transactions in the world, in-memory.
    /// </summary>
    public class InMemoryWorldManager : IWorldManager
    {
        public InMemoryWorldManager(ContentProvider contentProvider)
        {
            this.World = OverworldGenerator.Make(contentProvider, this); // TODO this would be loaded from somewhere
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
                    //entity.InteractWith(collisionTile);
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

            if (isPrecisionMove)
            {
                if (newOrientation == entity.FacingDirection)
                {
                    var rect = entity.Position;
                    rect.Location = targetLocation;
                    entity.Position = rect;
                }
                else
                {
                    entity.FacingDirection = newOrientation;
                }
            }
            else
            {
                var rect = entity.Position;
                rect.Location = targetLocation;
                entity.Position = rect;
                entity.FacingDirection = newOrientation;
            }
        }
    }
}
