namespace OpenAnt.World
{
    using Microsoft.Xna.Framework;
    using Entity;

    public interface INotifyWorldChangeRequested
    {
        void OnNotifyWorldChangeRequested(InteractableGameEntityBase sender, Point targetLocation, object action);
    }
}