namespace OpenAnt.Screen
{
    #region using directives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Engine;
    using Entity;
    using Services;
    using Microsoft.Xna.Framework.Input;

    #endregion

    /// <summary>
    /// Renders world data with an eagle-eye perspective.
    /// </summary>
    /// TODO centralize viewport after update
    /// // this.canvas.CentralizeViewport(this.worldManager.World.Player.Position.X, this.worldManager.World.Player.Position.Y);
    public abstract class EagleEyeScreenBase : ScreenBase
    {
        /// <summary>
        /// The screen world boundary.
        /// </summary>
        protected readonly Rectangle WorldBoundary;

        /// <summary>
        /// The segoe font sprite data.
        /// </summary>
        private readonly SpriteFont segoeFont;

        /// <summary>
        /// The entity factory.
        /// </summary>
        private readonly EntityFactory entityFactory;

        /// <summary>
        /// The build timestamp to use.
        /// </summary>
        private readonly string buildstamp = DateTime.Today.ToString("yyyyMMdd");

        /// <summary>
        /// The screen viewport.
        /// </summary>
        private Rectangle viewport;

        /// <summary>
        /// Initializes a new instance of the <see cref="EagleEyeScreenBase"/> class.
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
        protected EagleEyeScreenBase(IWorldManager worldManager, ContentProvider contentProvider, Rectangle worldBoundary)
            : base(worldManager)
        {
            this.segoeFont = contentProvider.GetFont(FontResource.SegoeUiMonoRegular);
            
            this.viewport = new Rectangle(0, 0, 30, 30);
            this.WorldBoundary = worldBoundary;

            this.entityFactory = new EntityFactory(contentProvider);

            // TODO query/subscribe for subset of world data
            this.SurfaceData = worldManager.SurfaceWorld.Where(o => o.Type == EntityType.TerrainSurface).Select(this.entityFactory.Create);
            
            //// this.SpriteData = worldManager.SurfaceWorld.Where(o => o.Type == EntityType.TerrainObstacle || o.Type == EntityType.Ant).Select(entityFactory.Create).ToList();
            
            // TODO this should not exist?
            this.Player = this.entityFactory.Create(worldManager.Player);
        }

        /// <summary>
        /// Gets the screen surface data.
        /// </summary>
        public IEnumerable<GameEntityBase> SurfaceData { get; private set; }

        /// <summary>
        /// Gets the screen sprite data.
        /// </summary>
        public IEnumerable<GameEntityBase> SpriteData
        {
            get
            {
                // TODO should subscribe for updates instead of full requery
                return this.WorldManager.SurfaceWorld.Where(o => o.Type == EntityType.TerrainObstacle || o.Type == EntityType.Ant).
                    Select(this.entityFactory.Create);
            }
        }

        /// <summary>
        /// Gets the screen focus entity.
        /// </summary>
        public GameEntityBase Player { get; private set; }

        /// <summary>
        /// Gets InputMapping.
        /// </summary>
        protected override IDictionary<Keys, Action> InputMappings
        {
            get
            {
                return new Dictionary<Keys, Action>
                           {
                               { Keys.D, () => this.WorldManager.PlayerMoveRequest(1, 0) },
                               { Keys.A, () => this.WorldManager.PlayerMoveRequest(-1, 0) },
                               { Keys.W, () => this.WorldManager.PlayerMoveRequest(0, -1) },
                               { Keys.S, () => this.WorldManager.PlayerMoveRequest(0, 1) },
                               { Keys.Space, () => this.WorldManager.Interact() },
                           };
            }
        }

        /// <summary>
        /// Draws any overlay artifacts after sprites and underlay have been drawn.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        public virtual void DrawOverlay(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.segoeFont, "OpenAnt.NET build " + this.buildstamp, new Vector2(5, 5), Color.White);             
        }

        /// <summary>
        /// Renders sprites in the world for this eage-eye perspective. Should be drawn after underlay.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        /// <param name="spriteData">
        /// The sprite data.
        /// </param>
        public void DrawSprites(SpriteBatch spriteBatch, IEnumerable<GameEntityBase> spriteData)
        {
            // TODO viewport restriction optimization);)
            foreach (var sprite in spriteData)
            {
                var viewportPosition = sprite.Position.Location;
                viewportPosition.X -= this.viewport.Left;
                viewportPosition.Y -= this.viewport.Top;
                sprite.Render(spriteBatch, viewportPosition);    
            }
        }

        /// <summary>
        /// Renders the underlay, before world sprites or the overlay placed on top.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        public virtual void DrawUnderlay(SpriteBatch spriteBatch)
        {
            /* Do nothing */
        }

        /// <summary>
        /// Centralizes the viewport on the given position.
        /// </summary>
        /// <param name="centerX">
        /// The center x.
        /// </param>
        /// <param name="centerY">
        /// The center y.
        /// </param>
        public void CentralizeViewport(int centerX, int centerY)
        {
            var viewportX = centerX - 20;
            var viewportY = centerY - 10;

            if (viewportX < 0)
            {
                viewportX = 0;
            }

            if (viewportY < 0)
            {
                viewportY = 0;
            }

            // TODO what's the formula for this...
            if (viewportX > this.WorldBoundary.Width - 35)
            {
                viewportX = this.WorldBoundary.Width - 35;
            }

            if (viewportY > this.WorldBoundary.Height - 24)
            {
                viewportY = this.WorldBoundary.Height - 24;
            }

            this.viewport.Location = new Point(viewportX, viewportY);
        }

        /// <summary>
        /// Draws graphical artifacts using the canvas.
        /// </summary>
        /// <param name="spriteBatch">
        /// The sprite batch.
        /// </param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.DrawUnderlay(spriteBatch);
            this.DrawSprites(spriteBatch, this.SurfaceData);
            this.DrawSprites(spriteBatch, this.SpriteData);
            this.DrawOverlay(spriteBatch);
        }
    }    
}

