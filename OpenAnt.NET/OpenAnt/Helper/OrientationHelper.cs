using Microsoft.Xna.Framework;

namespace OpenAnt.Helper
{
    public static class OrientationHelper
    {
        public static Point GetAdjacentPointDelta(Orientation relative)
        {
            Point heldEntityPosition = Point.Zero;
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

        public static Orientation GetFacingDirection(Point oldPosition, Point newPosition)
        {
            var xDiff = newPosition.X - oldPosition.X;
            var yDiff = newPosition.Y - oldPosition.Y;

            Orientation newOrientation = Orientation.North;
            if (xDiff == 0)
            {
                if (yDiff > 0)
                    newOrientation = Orientation.South;
                else
                    newOrientation = Orientation.North;
            }
            else if (xDiff > 0)
            {
                if (yDiff == 0)
                    newOrientation = Orientation.East;
                else if (yDiff < 0)
                    newOrientation = Orientation.NorthEast;
                else
                    newOrientation = Orientation.SouthEast;
            }
            else if (xDiff < 0)
            {
                if (xDiff < 0 && yDiff == 0)
                    newOrientation = Orientation.West;
                else if (yDiff < 0)
                    newOrientation = Orientation.NorthWest;
                else
                    newOrientation = Orientation.SouthWest;
            }

            return newOrientation;
        }

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
