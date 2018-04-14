using System;
using Microsoft.Xna.Framework;

namespace MagicalThings
{
    public delegate void ExtraAction();

    public static class Helper
    {
        public static Vector2 VelocityToPoint(Vector2 A, Vector2 B, float Speed)
        {
            Vector2 Move = (B - A);
            return Move * (Speed / (float)Math.Sqrt(Move.X * Move.X + Move.Y * Move.Y));
        }
    }
}
