namespace OpenAnt.Engine
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Data;
    using Entity;

    /// <summary>
    /// The world manager, which handles transactions in the world.
    /// </summary>
    public interface IWorldManager
    {
        /// <summary>
        /// Gets world surface data.
        /// </summary>
        IEnumerable<WorldData> SurfaceWorld { get; }

        /// <summary>
        /// Gets Player.
        /// </summary>
        /// <remarks>
        /// NOTE temporary.
        /// </remarks>
        WorldData Player { get; }

        /// <summary>
        /// Gets the collidable entity at the given location.
        /// </summary>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <returns>
        /// The collidable entity at the location.
        /// </returns>
        GameEntityBase GetEntityAt(Point location);

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
        void PlayerMoveRequest(int deltaX, int deltaY);

        /// <summary>
        /// Performs a player interaction.
        /// </summary>
        /// <remarks>
        /// TODO need to support player index.
        /// </remarks>
        void Interact();

        /// <summary>
        /// Perform world manager updates.
        /// </summary>
        void Update();
    }
}