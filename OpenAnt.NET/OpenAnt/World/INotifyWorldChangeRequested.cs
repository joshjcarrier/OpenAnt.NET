namespace OpenAnt.World
{
    using Microsoft.Xna.Framework;
    using Entity;

    /// <summary>
    /// Notification to modify the world.
    /// </summary>
    public interface INotifyWorldChangeRequested
    {
        /// <summary>
        /// Requests to modify the world data.
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
        void OnNotifyWorldChangeRequested(GameEntityBase sender, Point targetLocation, object action);
    }
}