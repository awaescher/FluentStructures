using System;
using System.Drawing;

namespace FluentStructures.Drawing
{
    public static class RectangleFExtensions
    {
        public static RectangleF WithX(this RectangleF r, float value) => new RectangleF(value, r.Y, r.Width, r.Height);

        public static RectangleF WithX(this RectangleF r, Func<float, float> modifier) => r.WithX(modifier(r.X));

        public static RectangleF WithAdditionalX(this RectangleF r, float value) => r.WithX(x => x + value);

        public static RectangleF WithY(this RectangleF r, float value) => new RectangleF(r.X, value, r.Width, r.Height);

        public static RectangleF WithY(this RectangleF r, Func<float, float> modifier) => r.WithY(modifier(r.Y));

        public static RectangleF WithAdditionalY(this RectangleF r, float value) => r.WithY(y => y + value);

        public static RectangleF WithWidth(this RectangleF r, float value) => new RectangleF(r.X, r.Y, value, r.Height);

        public static RectangleF WithWidth(this RectangleF r, Func<float, float> modifier) => r.WithWidth(modifier(r.Width));

        public static RectangleF WithAdditionalWidth(this RectangleF r, float value) => r.WithWidth(w => w + value);

        public static RectangleF WithHeight(this RectangleF r, float value) => new RectangleF(r.X, r.Y, r.Width, value);

        public static RectangleF WithHeight(this RectangleF r, Func<float, float> modifier) => r.WithHeight(modifier(r.Height));

        public static RectangleF WithAdditionalHeight(this RectangleF r, float value) => r.WithHeight(h => h + value);

        public static RectangleF WithLeft(this RectangleF r, float value) => r.WithX(value);

        public static RectangleF WithLeft(this RectangleF r, Func<float, float> modifier) => r.WithX(modifier);

        public static RectangleF WithAdditionalLeft(this RectangleF r, float value) => r.WithAdditionalX(value);

        public static RectangleF WithTop(this RectangleF r, float value) => r.WithY(value);

        public static RectangleF WithTop(this RectangleF r, Func<float, float> modifier) => r.WithY(modifier);

        public static RectangleF WithAdditionalTop(this RectangleF r, float value) => r.WithAdditionalY(value);

        public static RectangleF WithRight(this RectangleF r, float value, ShapeAdjustment adjustment)
        {
            var difference = value - r.Right;

            if (adjustment == ShapeAdjustment.Resize)
                return r.WithWidth(w => w + difference);

            return r.WithX(x => x + difference);
        }

        public static RectangleF WithRight(this RectangleF r, Func<float, float> modifier, ShapeAdjustment adjustment) => r.WithRight(modifier(r.Right), adjustment);

        public static RectangleF WithBottom(this RectangleF r, float value, ShapeAdjustment adjustment)
        {
            var difference = value - r.Bottom;

            if (adjustment == ShapeAdjustment.Resize)
                return r.WithHeight(h => h + difference);

            return r.WithY(y => y + difference);
        }

        public static RectangleF WithBottom(this RectangleF r, Func<float, float> modifier, ShapeAdjustment adjustment) => r.WithBottom(modifier(r.Bottom), adjustment);

        public static RectangleF WithLocation(this RectangleF r, float x, float y) => new RectangleF(x, y, r.Width, r.Height);

        public static RectangleF WithLocation(this RectangleF r, PointF location) => r.WithLocation(location.X, location.Y);

        public static RectangleF WithLocation(this RectangleF r, Func<PointF, PointF> modifier) => r.WithLocation(modifier(r.Location));

        public static RectangleF WithSize(this RectangleF r, float width, float height) => new RectangleF(r.X, r.Y, width, height);

        public static RectangleF WithSize(this RectangleF r, SizeF size) => r.WithSize(size.Width, size.Height);

        public static RectangleF WithSize(this RectangleF r, Func<SizeF, SizeF> modifier) => r.WithSize(modifier(r.Size));

        public static PointF GetPoint(this RectangleF r, ContentAlignment alignment) => r.Size.GetPoint(alignment).WithAdditionalX(r.X).WithAdditionalY(r.Y);

        public static RectangleF Align(this RectangleF r, SizeF sizeToAlign, ContentAlignment alignment) => r.Size.Align(sizeToAlign, alignment).WithAdditionalX(r.X).WithAdditionalY(r.Y);

        public static RectangleF Align(this RectangleF r, RectangleF rectangleToAlign, ContentAlignment alignment) => r.Align(rectangleToAlign.Size, alignment);
    }
}