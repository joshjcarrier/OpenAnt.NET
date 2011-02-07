namespace OpenAnt.Helper
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Helper functions for orientation operations.
    /// </summary>
    public static class OrientationHelper
    {
        /// <summary>
        /// Gets the delta co-ordinate correlated with the orientation.
        /// </summary>
        /// <param name="relative">
        /// The relative.
        /// </param>
        /// <returns>
        /// The delta co-ordinate.
        /// </returns>
        public static Point GetAdjacentPointDelta(Orientation relative)
        {
            var heldEntityPosition = Point.Zero;
            switch (relative)
            {
                case Orientation.North:
                    heldEntityPosition.Y -= 1;
                    break;
                case Orientation.NorthEast:
                    heldEntityPosition.X += 1;
                    heldEntityPosition.Y -= 1;
                    break;
                case Orientation.East:
                    heldEntityPosition.X += 1;
                    break;
                case Orientation.SouthEast:
                    heldEntityPosition.X += 1;
                    heldEntityPosition.Y += 1;
                    break;
                case Orientation.South:
                    heldEntityPosition.Y += 1;
                    break;
                case Orientation.SouthWest:
                    heldEntityPosition.X -= 1;
                    heldEntityPosition.Y += 1;
                    break;
                case Orientation.West:
                    heldEntityPosition.X -= 1;
                    break;
                case Orientation.NorthWest:
                    heldEntityPosition.X -= 1;
                    heldEntityPosition.Y -= 1;
                    break;
            }

            return heldEntityPosition;
        }

        /// <summary>
        /// Gets the orientation relative to the old and new position.
        /// </summary>
        /// <param name="oldPosition">
        /// The old position.
        /// </param>
        /// <param name="newPosition">
        /// The new position.
        /// </param>
        /// <returns>
        /// The calculated orientation.
        /// </returns>
        public static Orientation GetFacingDirection(Point oldPosition, Point newPosition)
        {
            var diffX = newPosition.X - oldPosition.X;
            var diffY = newPosition.Y - oldPosition.Y;

            var newOrientation = Orientation.North;
            if (diffX == 0)
            {
                if (diffY > 0)
                {
                    newOrientation = Orientation.South;
                }
                else
                {
                    newOrientation = Orientation.North;
                }
            }
            else if (diffX > 0)
            {
                if (diffY == 0)
                {
                    newOrientation = Orientation.East;
                }
                else if (diffY < 0)
                {
                    newOrientation = Orientation.NorthEast;
                }
                else
                {
                    newOrientation = Orientation.SouthEast;
                }
            }
            else if (diffX < 0)
            {
                if (diffX < 0 && diffY == 0)
                {
                    newOrientation = Orientation.West;
                }
                else if (diffY < 0)
                {
                    newOrientation = Orientation.NorthWest;
                }
                else
                {
                    newOrientation = Orientation.SouthWest;
                }
            }

            return newOrientation;
        }

        /// <summary>
        /// Gets the rotation angle for the given orientation.
        /// </summary>
        /// <param name="orientation">
        /// The orientation.
        /// </param>
        /// <returns>
        /// The rotation angle.
        /// </returns>
        public static float GetRotationAngle(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.North:
                    return 0F;
                case Orientation.NorthEast:
                    return MathHelper.PiOver4;
                case Orientation.East:
                    return MathHelper.PiOver2;
                case Orientation.SouthEast:
                    return 3 * MathHelper.PiOver4;
                case Orientation.South:
                    return MathHelper.Pi;
                case Orientation.SouthWest:
                    return 5 * MathHelper.PiOver4;
                case Orientation.West:
                    return 3 * MathHelper.PiOver2;
                case Orientation.NorthWest:
                    return 7 * MathHelper.PiOver4;
                default:
                    return 0F;
            }
        }
    }
}
