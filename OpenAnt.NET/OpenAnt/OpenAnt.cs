namespace OpenAnt
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Screen;
    using Canvas;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class OpenAnt : Game
    {
        /// <summary>
        /// The sprite batch used for rendering.
        /// </summary>
        private SpriteBatch spriteBatch;

        /// <summary>
        /// The main menu screen.
        /// </summary>
        private MainMenuScreen mainMenuScreen;

        /// <summary>
        /// The game canvas screen.
        /// </summary>
        private GameCanvasScreen gameCanvasScreen;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAnt"/> class.
        /// </summary>
        public OpenAnt()
        {
            // initializes the graphics device manager
            new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.mainMenuScreen = new MainMenuScreen();
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            // in case a texture fails to load, this is used in its place
            var nullTexture = new Texture2D(this.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            nullTexture.SetData(new[] { Color.White });

            // loads and provides content
            var contentProvider = new ContentProvider(this.Content, nullTexture);

            // graphical interface
            this.gameCanvasScreen = new GameCanvasScreen(contentProvider);

            ViewportHelper.CurrentDevice = GraphicsDevice;
            ViewportHelper.DefaultViewport = GraphicsDevice.Viewport;
            Viewport viewport = GraphicsDevice.Viewport;
            viewport.Width -= 100;
            viewport.X = 100;
            ViewportHelper.SpriteViewport = viewport;

            viewport = GraphicsDevice.Viewport;
            viewport.Width = 100;
            ViewportHelper.MenuViewport = viewport;

            GraphicsDevice.Viewport = ViewportHelper.SpriteViewport;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }

            // TODO: Add your update logic here
            this.mainMenuScreen.Update();
            this.gameCanvasScreen.Update(Keyboard.GetState(PlayerIndex.One));

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: smartly switch between screens
            // this.mainMenuScreen.Draw(this.spriteBatch);
            this.gameCanvasScreen.Draw(this.spriteBatch);

            base.Draw(gameTime);
        }
    }
}
