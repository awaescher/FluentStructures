using System;
using System.Drawing;

namespace FluentStructures.Drawing
{
    public static class ColorExtensions
    {
        public static Color WithAlpha(this Color c, int a) => Color.FromArgb(a, c.R, c.G, c.B);

        public static Color WithAlpha(this Color c, Func<int, int> modifier) => c.WithAlpha(modifier(c.A));

        public static Color WithAdditionalAlpha(this Color c, int value) => WithAlpha(c, a => a + value);

        public static Color WithRed(this Color c, int r) => Color.FromArgb(c.A, r, c.G, c.B);

        public static Color WithRed(this Color c, Func<int, int> modifier) => c.WithRed(modifier(c.R));

        public static Color WithAdditionalRed(this Color c, int value) => WithRed(c, r => r + value);

        public static Color WithGreen(this Color c, int g) => Color.FromArgb(c.A, c.R, g, c.B);

        public static Color WithGreen(this Color c, Func<int, int> modifier) => c.WithGreen(modifier(c.G));

        public static Color WithAdditionalGreen(this Color c, int value) => c.WithGreen(g => g + value);

        public static Color WithBlue(this Color c, int b) => Color.FromArgb(c.A, c.R, c.G, b);

        public static Color WithBlue(this Color c, Func<int, int> modifier) => c.WithBlue(modifier(c.B));

        public static Color WithAdditionalBlue(this Color c, int value) => WithBlue(c, b => b + value);
    }
}