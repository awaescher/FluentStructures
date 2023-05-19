using System;
using System.Drawing;

namespace FluentStructures.Drawing
{
    public static class PointExtensions
    {
        public static Point WithX(this Point p, int value) => new Point(value, p.Y);

        public static Point WithX(this Point p, Func<int, int> modifier) => p.WithX(modifier(p.X));

        public static Point WithAdditionalX(this Point p, int value) => p.WithX(x => x + value);

        public static Point WithY(this Point p, int value) => new Point(p.X, value);

        public static Point WithY(this Point p, Func<int, int> modifier) => p.WithY(modifier(p.Y));

        public static Point WithAdditionalY(this Point p, int value) => p.WithY(y => y + value);
    }
}