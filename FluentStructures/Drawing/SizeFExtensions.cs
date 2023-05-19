using System;
using System.Drawing;

namespace FluentStructures.Drawing
{
    public static class SizeFExtensions
    {
        public static SizeF WithWidth(this SizeF s, float value) => new SizeF(value, s.Height);

        public static SizeF WithWidth(this SizeF s, Func<float, float> modifier) => s.WithWidth(modifier(s.Width));

        public static SizeF WithAdditionalWidth(this SizeF s, float value) => s.WithWidth(w => w + value);

        public static SizeF WithHeight(this SizeF s, float value) => new SizeF(s.Width, value);

        public static SizeF WithHeight(this SizeF s, Func<float, float> modifier) => s.WithHeight(modifier(s.Height));

        public static SizeF WithAdditionalHeight(this SizeF s, float value) => s.WithHeight(h => h + value);

        public static PointF GetPoint(this SizeF s, ContentAlignment alignment)
        {
            var halfWidth = s.Width / 2;
            var halfHeight = s.Height / 2;

            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                    return new PointF(0, 0);
                case ContentAlignment.TopCenter:
                    return new PointF(halfWidth, 0);
                case ContentAlignment.TopRight:
                    return new PointF(s.Width, 0);
                case ContentAlignment.MiddleLeft:
                    return new PointF(0, halfHeight);
                case ContentAlignment.MiddleCenter:
                    return new PointF(halfWidth, halfHeight);
                case ContentAlignment.MiddleRight:
                    return new PointF(s.Width, halfHeight);
                case ContentAlignment.BottomLeft:
                    return new PointF(0, s.Height);
                case ContentAlignment.BottomCenter:
                    return new PointF(halfWidth, s.Height);
                case ContentAlignment.BottomRight:
                    return new PointF(s.Width, s.Height);
            }

            throw new NotSupportedException($"alignment {alignment} not supported.");
        }

        public static RectangleF Align(this SizeF s, SizeF sizeToAlign, ContentAlignment alignment)
        {
            var addX = 0f;
            var addY = 0f;

            if (alignment.IsLeft())
                addX = 0f;
            else if (alignment.IsCenter())
                addX = -1f * sizeToAlign.Width / 2f;
            else if (alignment.IsRight())
                addX = -1f * sizeToAlign.Width;

            if (alignment.IsTop())
                addY = 0f;
            else if (alignment.IsMiddle())
                addY = -1f * sizeToAlign.Height / 2f;
            else if (alignment.IsBottom())
                addY = -1f * sizeToAlign.Height;

            var location = s.GetPoint(alignment).WithAdditionalX(addX).WithAdditionalY(addY);
            return new RectangleF(location, sizeToAlign);
        }
    }
}