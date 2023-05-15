using System;
using System.Drawing;

namespace FluentStructures.Drawing
{
    public static class RectangleExtensions
    {
        public static Rectangle WithX(this Rectangle r, int value) => new Rectangle(value, r.Y, r.Width, r.Height);

        public static Rectangle WithX(this Rectangle r, Func<int, int> modifier) => r.WithX(modifier(r.X));

        public static Rectangle AddX(this Rectangle r, int value) => r.WithX(x => x + value);

        public static Rectangle WithY(this Rectangle r, int value) => new Rectangle(r.X, value, r.Width, r.Height);

        public static Rectangle WithY(this Rectangle r, Func<int, int> modifier) => r.WithY(modifier(r.Y));

        public static Rectangle AddY(this Rectangle r, int value) => r.WithY(y => y + value);

        public static Rectangle WithWidth(this Rectangle r, int value) => new Rectangle(r.X, r.Y, value, r.Height);

        public static Rectangle WithWidth(this Rectangle r, Func<int, int> modifier) => r.WithWidth(modifier(r.Width));

        public static Rectangle AddWidth(this Rectangle r, int value) => r.WithWidth(w => w + value);

        public static Rectangle WithHeight(this Rectangle r, int value) => new Rectangle(r.X, r.Y, r.Width, value);

        public static Rectangle WithHeight(this Rectangle r, Func<int, int> modifier) => r.WithHeight(modifier(r.Height));

        public static Rectangle AddHeight(this Rectangle r, int value) => r.WithHeight(h => h + value);

        public static Rectangle WithLeft(this Rectangle r, int value) => r.WithX(value);

        public static Rectangle WithLeft(this Rectangle r, Func<int, int> modifier) => r.WithX(modifier);

        public static Rectangle AddLeft(this Rectangle r, int value) => r.AddX(value);

        public static Rectangle WithTop(this Rectangle r, int value) => r.WithY(value);

        public static Rectangle WithTop(this Rectangle r, Func<int, int> modifier) => r.WithY(modifier);

        public static Rectangle AddTop(this Rectangle r, int value) => r.AddY(value);

        public static Rectangle WithRight(this Rectangle r, int value, ShapeAdjustment adjustment)
        {
            var difference = value - r.Right;

            if (adjustment == ShapeAdjustment.Resize)
                return r.WithWidth(w => w + difference);

            return r.WithX(x => x + difference);
        }

        public static Rectangle WithRight(this Rectangle r, Func<int, int> modifier, ShapeAdjustment adjustment) => r.WithRight(modifier(r.Right), adjustment);

        public static Rectangle WithBottom(this Rectangle r, int value, ShapeAdjustment adjustment)
        {
            var difference = value - r.Bottom;

            if (adjustment == ShapeAdjustment.Resize)
                return r.WithHeight(h => h + difference);

            return r.WithY(y => y + difference);
        }

        public static Rectangle WithBottom(this Rectangle r, Func<int, int> modifier, ShapeAdjustment adjustment) => r.WithBottom(modifier(r.Bottom), adjustment);

        public static Rectangle WithLocation(this Rectangle r, int x, int y) => new Rectangle(x, y, r.Width, r.Height);

        public static Rectangle WithLocation(this Rectangle r, Point location) => r.WithLocation(location.X, location.Y);

        public static Rectangle WithLocation(this Rectangle r, Func<Point, Point> modifier) => r.WithLocation(modifier(r.Location));

        public static Rectangle WithSize(this Rectangle r, int width, int height) => new Rectangle(r.X, r.Y, width, height);

        public static Rectangle WithSize(this Rectangle r, Size size) => r.WithSize(size.Width, size.Height);

        public static Rectangle WithSize(this Rectangle r, Func<Size, Size> modifier) => r.WithSize(modifier(r.Size));

        public static Point GetPoint(this Rectangle r, ContentAlignment alignment) => r.Size.GetPoint(alignment).AddX(r.X).AddY(r.Y);

        public static Rectangle Align(this Rectangle r, Size sizeToAlign, ContentAlignment alignment) => r.Size.Align(sizeToAlign, alignment).AddX(r.X).AddY(r.Y);

        public static Rectangle Align(this Rectangle r, Rectangle rectangleToAlign, ContentAlignment alignment) => r.Align(rectangleToAlign.Size, alignment);
    }
}