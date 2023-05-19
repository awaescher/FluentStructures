using System;
using System.Drawing;

namespace FluentStructures.Drawing
{
    public static class SizeExtensions
    {
        public static Size WithWidth(this Size s, int value) => new Size(value, s.Height);

        public static Size WithWidth(this Size s, Func<int, int> modifier) => s.WithWidth(modifier(s.Width));

        public static Size WithAdditionalWidth(this Size s, int value) => s.WithWidth(w => w + value);

        public static Size WithHeight(this Size s, int value) => new Size(s.Width, value);

        public static Size WithHeight(this Size s, Func<int, int> modifier) => s.WithHeight(modifier(s.Height));

        public static Size WithAdditionalHeight(this Size s, int value) => s.WithHeight(h => h + value);

        public static Point GetPoint(this Size s, ContentAlignment alignment)
        {
            var halfWidth = s.Width / 2;
            var halfHeight = s.Height / 2;

            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                    return new Point(0, 0);
                case ContentAlignment.TopCenter:
                    return new Point(halfWidth, 0);
                case ContentAlignment.TopRight:
                    return new Point(s.Width, 0);
                case ContentAlignment.MiddleLeft:
                    return new Point(0, halfHeight);
                case ContentAlignment.MiddleCenter:
                    return new Point(halfWidth, halfHeight);
                case ContentAlignment.MiddleRight:
                    return new Point(s.Width, halfHeight);
                case ContentAlignment.BottomLeft:
                    return new Point(0, s.Height);
                case ContentAlignment.BottomCenter:
                    return new Point(halfWidth, s.Height);
                case ContentAlignment.BottomRight:
                    return new Point(s.Width, s.Height);
            }

            throw new NotSupportedException($"alignment {alignment} not supported.");
        }

        public static Rectangle Align(this Size s, Size sizeToAlign, ContentAlignment alignment)
        {
            var addX = 0;
            var addY = 0;

            if (alignment.IsLeft())
                addX = 0;
            else if (alignment.IsCenter())
                addX = -1 * sizeToAlign.Width / 2;
            else if (alignment.IsRight())
                addX = -1 * sizeToAlign.Width;

            if (alignment.IsTop())
                addY = 0;
            else if (alignment.IsMiddle())
                addY = -1 * sizeToAlign.Height / 2;
            else if (alignment.IsBottom())
                addY = -1 * sizeToAlign.Height;

            var location = s.GetPoint(alignment).WithAdditionalX(addX).WithAdditionalY(addY);
            return new Rectangle(location, sizeToAlign);
        }
    }
}