namespace OpenAnt.Entity.Policy.Render
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #region using directives

    

    #endregion

    /// <summary>
    /// Interface allowing entity to be renderable.
    /// </summary>
    public interface IRenderPolicy
    {
        Point EntitySize { get; }

        void Render(SpriteBatch spriteBatch, Point viewportPosition);
    }
}
