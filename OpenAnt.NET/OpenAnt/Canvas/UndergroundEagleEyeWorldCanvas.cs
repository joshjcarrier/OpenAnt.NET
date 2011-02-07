namespace OpenAnt.Canvas
{
    #region using directives
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    #endregion

    public class UndergroundEagleEyeWorldCanvas : EagleEyeWorldCanvas
    {
        public UndergroundEagleEyeWorldCanvas(ContentProvider contentProvider, Rectangle worldBoundary) : base(contentProvider, worldBoundary)
        {
        }

        public override void DrawOverlay(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, new Rectangle(0, 40 - this.Viewport.Y * 20, 800, 4), Color.Green);
        }

        public override void DrawUnderlay(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, new Rectangle(0, 40 - this.Viewport.Y * 20, 800, 260), Color.SandyBrown);
            //spriteBatch.Draw(texture, new Rectangle(0, 300 - this.Viewport.Y * 20, 800, 500), Color.RosyBrown);
        }
    }
}
