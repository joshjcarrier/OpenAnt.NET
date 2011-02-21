namespace OpenAnt.Screen
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Engine;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Decides how to show in-game overlays and input interpretation..
    /// </summary>
    public class ScreenControlHost : IScreen
    {
        /// <summary>
        /// Available game screens.
        /// </summary>
        private readonly IList<IScreen> screens;
        
        /// <summary>
        /// The world manager.
        /// </summary>
        private readonly IWorldManager worldManager;

        /// <summary>
        /// The current game engine.
        /// </summary>
        private int currentEngine;
       
        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenControlHost"/> class.
        /// </summary>
        /// <param name="worldManager">
        /// The world Manager.
        /// </param>
        /// <param name="contentProvider">
        /// The content provider.
        /// </param>
        /// <param name="worldBoundary">
        /// The world Boundary.
        /// </param>
        public ScreenControlHost(IWorldManager worldManager, ContentProvider contentProvider, Rectangle worldBoundary)
        {
            this.worldManager = worldManager;

            // TODO state machine flips between screens
            // TODO subscribe to engine change events
            this.screens = new List<IScreen>();
            this.screens.Add(new OverworldScreen(worldManager, contentProvider, worldBoundary));

            // this.screens.Add(new UndergroundScreen(contentProvider));
            this.currentEngine = 0;
        }

        /// <summary>
        /// Draws for current state engine.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // gameplay
            spriteBatch.Begin();

            // ViewportHelper.CurrentDevice.Viewport = ViewportHelper.SpriteViewport;
            this.screens[this.currentEngine].Draw(spriteBatch);

            // TODO menu
            // this.DrawMenuOverlay(spriteBatch);
            spriteBatch.End();

            // spriteBatch.Begin();
            // ViewportHelper.CurrentDevice.Viewport = ViewportHelper.MenuViewport;
            // this.DrawMenuOverlay(spriteBatch);
            // spriteBatch.End();
        }

        /// <summary>
        /// Update the screens and process input.
        /// </summary>
        /// <param name="keyboardState">
        /// The keyboard state.
        /// </param>
        public void Update(KeyboardState keyboardState)
        {
            this.worldManager.Update();

            this.screens[this.currentEngine].Update(keyboardState);
        }
    }
}
