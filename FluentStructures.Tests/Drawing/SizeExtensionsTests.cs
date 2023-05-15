using System.Drawing;
using FluentAssertions;
using FluentStructures.Drawing;

namespace FluentStructures.Tests.Drawing
{
    public class SizeExtensionsTests
    {
        private readonly Size _size = new(1, 2);

        public class AbsoluteWithMethods : SizeExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Set_Width()
            {
                var size = _size.WithWidth(10);

                size.Width.Should().Be(10);
                size.Height.Should().Be(2);
            }

            [Test]
            public void Can_Be_Used_To_Set_Height()
            {
                var size = _size.WithHeight(10);

                size.Width.Should().Be(1);
                size.Height.Should().Be(10);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var size = _size.WithWidth(10).WithHeight(11);

                size.Width.Should().Be(10);
                size.Height.Should().Be(11);
            }
        }

        public class ModifyingWithMethods : SizeExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Set_Width()
            {
                var size = _size.WithWidth(w => w + 10);

                size.Width.Should().Be(1 + 10);
                size.Height.Should().Be(2);
            }

            [Test]
            public void Can_Be_Used_To_Set_Height()
            {
                var size = _size.WithHeight(h => h + 10);

                size.Width.Should().Be(1);
                size.Height.Should().Be(2 + 10);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var size = _size.WithWidth(w => w + 10).WithHeight(h => h + 11);

                size.Width.Should().Be(1 + 10);
                size.Height.Should().Be(2 + 11);
            }
        }

        public class AddMethods : SizeExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Add_Width()
            {
                var size = _size.AddWidth(10);

                size.Width.Should().Be(11);
                size.Height.Should().Be(2);
            }

            [Test]
            public void Can_Be_Used_To_Set_Height()
            {
                var size = _size.AddHeight(10);

                size.Width.Should().Be(1);
                size.Height.Should().Be(12);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var size = _size.AddWidth(10).AddHeight(11);

                size.Width.Should().Be(11);
                size.Height.Should().Be(13);
            }
        }

        public class GetPointMethod : SizeExtensionsTests
        {
            [TestCase(ContentAlignment.TopLeft, 0, 0)]
            [TestCase(ContentAlignment.TopCenter, 50, 0)]
            [TestCase(ContentAlignment.TopRight, 100, 0)]
            [TestCase(ContentAlignment.MiddleLeft, 0, 200)]
            [TestCase(ContentAlignment.MiddleCenter, 50, 200)]
            [TestCase(ContentAlignment.MiddleRight, 100, 200)]
            [TestCase(ContentAlignment.BottomLeft, 0, 400)]
            [TestCase(ContentAlignment.BottomCenter, 50, 400)]
            [TestCase(ContentAlignment.BottomRight, 100, 400)]
            public void Returns_Relative_Point(ContentAlignment alignment, int expectedX, int expectedY)
            {
                var point = new Size(100, 400).GetPoint(alignment);

                point.X.Should().Be(expectedX);
                point.Y.Should().Be(expectedY);
            }
        }

        public class AlignMethod : SizeExtensionsTests
        {
            [TestCase(ContentAlignment.TopLeft, 0, 0)]
            [TestCase(ContentAlignment.TopCenter, 200, 0)]
            [TestCase(ContentAlignment.TopRight, 400, 0)]
            [TestCase(ContentAlignment.MiddleLeft, 0, 90)]
            [TestCase(ContentAlignment.MiddleCenter, 200, 90)]
            [TestCase(ContentAlignment.MiddleRight, 400, 90)]
            [TestCase(ContentAlignment.BottomLeft, 0, 180)]
            [TestCase(ContentAlignment.BottomCenter, 200, 180)]
            [TestCase(ContentAlignment.BottomRight, 400, 180)]
            public void Returns_The_Aligned_Rectangle(ContentAlignment alignment, int expectedRectX, int expectedRectY)
            {
                var outer = new Size(500, 300);
                var inner = new Size(100, 120);
                var centeredRectangle = outer.Align(inner, alignment);

                centeredRectangle.X.Should().Be(expectedRectX);
                centeredRectangle.Y.Should().Be(expectedRectY);
            }
        }
    }
}