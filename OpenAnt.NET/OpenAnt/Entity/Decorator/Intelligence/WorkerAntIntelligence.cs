namespace OpenAnt.Entity.Decorator.Intelligence
{
    using System;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Artificial intelligence for a worker ant.
    /// </summary>
    public class WorkerAntIntelligence : GameEntityDecorator
    {
        public WorkerAntIntelligence(GameEntityBase entity) : base(entity)
        {
        }

        static Random r = new Random();

        public override Point UpdateAwareness()
        {
            // TODO some real awareness
            var location = Point.Zero;

            var testX = r.Next(100);
            var testY = r.Next(100);

            if (testX > 40)
            {
                return location;
            }

            location.X = (testX % 3) - 1;
            location.Y = (testY % 3) - 1;

            return location;
        }
    }
}
