using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentStructures.Drawing;

namespace FluentStructures.Tests
{
    public class ShowCases
    {
        [Test]
        public void Case_Middle_Center()
        {
            //    ┌──────────────────────────────────┐
            //    │                                  │
            //    │              ┌────┐              │
            //    │              │    │              │
            //    │              └────┘              │
            //    │                                  │
            //    └──────────────────────────────────┘

            var cellBounds = new Rectangle(100, 100, 300, 150);
            var userImage = new Bitmap(30, 30);

            var traditionalCalculation = new Rectangle(
                cellBounds.X + ((cellBounds.Width - userImage.Width) / 2),
                cellBounds.Y + ((cellBounds.Height - userImage.Height) / 2),
                userImage.Width,
                userImage.Height);

            var fluentCalculation = cellBounds.Align(userImage.Size, ContentAlignment.MiddleCenter);

            foreach (var r in new[] { traditionalCalculation, fluentCalculation })
            {
                r.Left.Should().Be(235);
                r.Top.Should().Be(160);
                r.Width.Should().Be(30);
                r.Height.Should().Be(30);
            }
        }

        [Test]
        public void Case_Middle_Right()
        {
            //    ┌──────────────────────────────────┐
            //    │                                  │
            //    │                         ┌────┐   │
            //    │                         │    │   │   <-- 10px padding
            //    │                         └────┘   │
            //    │                                  │
            //    └──────────────────────────────────┘

            var cellBounds = new Rectangle(100, 100, 300, 150);
            var userImage = new Bitmap(30, 30);

            var traditionalCalculation = new Rectangle(
                cellBounds.Right - userImage.Width - 10,
                cellBounds.Y + ((cellBounds.Height - userImage.Height) / 2),
                userImage.Width,
                userImage.Height);

            var fluentCalculation = cellBounds
                .Align(userImage.Size, ContentAlignment.MiddleRight)
                .AddLeft(-10);

            foreach (var r in new[] { traditionalCalculation, fluentCalculation })
            {
                r.Left.Should().Be(360);
                r.Top.Should().Be(160);
                r.Width.Should().Be(30);
                r.Height.Should().Be(30);
            }
        }
    }

    public class Bitmap
    {
        public Bitmap(int width, int height)
        {
            Size = new Size(width, height);
        }

        public Size Size { get; set; }

        public int Height => Size.Height;

        public int Width => Size.Width;
    }
}
