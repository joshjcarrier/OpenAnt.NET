namespace OpenAnt.World
{
    using Microsoft.Xna.Framework;
    using Entity;

    public interface INotifyWorldChangeRequested
    {
        void OnNotifyWorldChangeRequested(GameEntityBase sender, Point targetLocation, object action);
    }
}