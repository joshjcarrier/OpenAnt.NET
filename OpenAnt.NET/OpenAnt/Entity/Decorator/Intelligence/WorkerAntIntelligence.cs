namespace OpenAnt.Entity.Decorator.Intelligence
{
    using System;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Artificial intelligence for a worker ant.
    /// </summary>
    public class WorkerAntIntelligence : GameEntityDecorator
    {
        /// <summary>
        /// Random number generator used to fuzz AI.
        /// </summary>
        private static readonly Random RandomGen = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkerAntIntelligence"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public WorkerAntIntelligence(GameEntityBase entity) : base(entity)
        {
        }

        /// <summary>
        /// Process entity decisions.
        /// </summary>
        /// <returns>
        /// The new location.
        /// </returns>
        /// <remarks>
        /// Remove return value.
        /// </remarks>
        public override Point UpdateAwareness()
        {
            // TODO some real awareness
            var location = Position.Location;

            var testX = RandomGen.Next(100);
            var testY = RandomGen.Next(100);

            if (testX > 40)
            {
                return location;
            }

            location.X += (testX % 3) - 1;
            location.Y += (testY % 3) - 1;

            //// this.OnNotifyWorldChangeRequested(location, ActionType.Move);

            return location;
        }
    }
}
