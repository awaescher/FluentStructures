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
        public void Moving_Points()
        {
			//   (p1)───────────────────────────────(p2)
			//                                       │
			//                                       │
			//                                       │   +50px
			//                                       │
			//                                       │
			//                         (p4)─────────(p3)
            //                               -33px

			// traditional
			var p1 = new Point(10, 10);
            var p2 = new Point(100, p1.Y);
            var p3 = new Point(p2.X, p2.Y + 50);
			var p4 = new Point(p3.X - 33, p3.Y);

			p3.Y.Should().Be(60);
            p4.X.Should().Be(67);

            // fluent
            p1 = new Point(10, 10);
            p2 = p1.WithX(100);
			p3 = p2.WithAdditionalY(50);
            p4 = p3.WithAdditionalX(-33);

			p3.Y.Should().Be(60);
            p4.X.Should().Be(67);
		}

		[Test]
		public void Landmarks()
		{
			//    ┌──────────────────────────────────┐
			//    │                                  │
			//    │                                  │
			//    │              (p1)                │
			//    │                                  │
			//    │                                  │
			//    └──────────────(p2)────────────────┘

			var rect = new Rectangle(100, 100, 300, 150);

            var p1 = new Point(rect.Left + (rect.Width / 2), rect.Top + (rect.Height / 2));
            var p2 = new Point(rect.Left + (rect.Width / 2), rect.Bottom);

            p1.X.Should().Be(250);
            p1.Y.Should().Be(175);
			p2.X.Should().Be(250);
			p2.Y.Should().Be(250);

			p1 = rect.GetLandmark(ContentAlignment.MiddleCenter);
            p2 = rect.GetLandmark(ContentAlignment.BottomCenter);

			p1.X.Should().Be(250);
			p1.Y.Should().Be(175);
			p2.X.Should().Be(250);
			p2.Y.Should().Be(250);
		}

		[Test]
        public void Align_Middle_Center()
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

            var fluentCalculation = cellBounds.Embed(userImage.Size, ContentAlignment.MiddleCenter);

            foreach (var r in new[] { traditionalCalculation, fluentCalculation })
            {
                r.Left.Should().Be(235);
                r.Top.Should().Be(160);
                r.Width.Should().Be(30);
                r.Height.Should().Be(30);
            }
        }

        [Test]
        public void Align_Middle_Right()
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
                .Embed(userImage.Size, ContentAlignment.MiddleRight)
                .WithAdditionalLeft(-10);

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
