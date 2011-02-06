namespace OpenAnt.Entity.Decorator.Interaction
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// An entity capable of having it's position changed in the world.
    /// </summary>
    public class MovingEntity : GameEntityDecorator
    {
        public MovingEntity(GameEntityBase entity) : base(entity)
        {
        }

        public override void Move(Point newPosition)
        {
            var oldPosition = Position;
            oldPosition.Location = newPosition;
            Position = oldPosition;
        }
    }
}
