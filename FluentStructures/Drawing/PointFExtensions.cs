using System;
using System.Drawing;

namespace FluentStructures.Drawing
{
    public static class PointFExtensions
    {
        public static PointF WithX(this PointF p, float value) => new PointF(value, p.Y);

        public static PointF WithX(this PointF p, Func<float, float> modifier) => p.WithX(modifier(p.X));

        public static PointF WithAdditionalX(this PointF p, float value) => p.WithX(x => x + value);

        public static PointF WithY(this PointF p, float value) => new PointF(p.X, value);

        public static PointF WithY(this PointF p, Func<float, float> modifier) => p.WithY(modifier(p.Y));

        public static PointF WithAdditionalY(this PointF p, float value) => p.WithY(y => y + value);
    }
}