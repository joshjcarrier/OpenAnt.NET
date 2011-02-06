namespace OpenAnt.Entity.Sprite
{
    using Microsoft.Xna.Framework;
    using Policy.Collision;
    using Policy.Render;

    /// <summary>
    /// Yellow ant entity.
    /// TODO this should derive from not game entity
    /// </summary>
    public class YellowAntEntity : GameEntity
    {
        protected YellowAntEntity(IRenderPolicy renderPolicy, ICollisionPolicy collisionPolicy, Rectangle position)
            : base(renderPolicy, collisionPolicy, position)
        {
        }

        public static GameEntity Create(ContentProvider contentProvider, Point position)
        {
            var renderable = new AnimatedRenderPolicy(contentProvider, new Point(1, 1));
            var collidable = new TransparentCollisionPolicy();
            return new YellowAntEntity(renderable, collidable, new Rectangle(position.X, position.Y, 1, 1));
        }
    }
}
