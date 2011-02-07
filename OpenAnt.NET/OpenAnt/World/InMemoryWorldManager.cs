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
