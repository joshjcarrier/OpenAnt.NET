namespace OpenAnt.Canvas
{
    using Microsoft.Xna.Framework.Graphics;

    public static class ViewportHelper
    {
        public static GraphicsDevice CurrentDevice { get; set; }
        public static Viewport DefaultViewport { get; set; }
        public static Viewport SpriteViewport{ get; set; }
        public static Viewport MenuViewport { get; set; }
    }
}
