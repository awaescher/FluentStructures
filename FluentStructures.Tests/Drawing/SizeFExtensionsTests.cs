using System.Drawing;
using FluentAssertions;
using FluentStructures.Drawing;

namespace FluentStructures.Tests.Drawing
{
    public class SizeFExtensionsTests
    {
        private readonly SizeF _size = new(1.1f, 2.2f);

        public class AbsoluteWithMethods : SizeFExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Set_Width()
            {
                var size = _size.WithWidth(10.1f);

                size.Width.Should().Be(10.1f);
                size.Height.Should().Be(2.2f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Height()
            {
                var size = _size.WithHeight(10.1f);

                size.Width.Should().Be(1.1f);
                size.Height.Should().Be(10.1f);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var size = _size.WithWidth(10.1f).WithHeight(11.1f);

                size.Width.Should().Be(10.1f);
                size.Height.Should().Be(11.1f);
            }
        }

        public class ModifyingWithMethods : SizeFExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Set_Width()
            {
                var size = _size.WithWidth(w => w + 10.1f);

                size.Width.Should().Be(1.1f + 10.1f);
                size.Height.Should().Be(2.2f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Height()
            {
                var size = _size.WithHeight(h => h + 10.1f);

                size.Width.Should().Be(1.1f);
                size.Height.Should().Be(2.2f + 10.1f);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var size = _size.WithWidth(w => w + 10.1f).WithHeight(h => h + 11.1f);

                size.Width.Should().Be(1.1f + 10.1f);
                size.Height.Should().Be(2.2f + 11.1f);
            }
        }

        public class WithAdditionalMethods : SizeFExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Add_Width()
            {
                var size = _size.WithAdditionalWidth(10.1f);

                size.Width.Should().Be(1.1f + 10.1f);
                size.Height.Should().Be(2.2f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Height()
            {
                var size = _size.WithAdditionalHeight(10.1f);

                size.Width.Should().Be(1.1f);
                size.Height.Should().Be(2.2f + 10.1f);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var size = _size.WithAdditionalWidth(10.1f).WithAdditionalHeight(11.1f);

                size.Width.Should().Be(1.1f + 10.1f);
                size.Height.Should().Be(2.2f + 11.1f);
            }
        }

        public class GetPointMethod : SizeFExtensionsTests
        {
            [TestCase(ContentAlignment.TopLeft, 0, 0)]
            [TestCase(ContentAlignment.TopCenter, 50.1f, 0)]
            [TestCase(ContentAlignment.TopRight, 100.2f, 0)]
            [TestCase(ContentAlignment.MiddleLeft, 0, 200.2f)]
            [TestCase(ContentAlignment.MiddleCenter, 50.1f, 200.2f)]
            [TestCase(ContentAlignment.MiddleRight, 100.2f, 200.2f)]
            [TestCase(ContentAlignment.BottomLeft, 0, 400.4f)]
            [TestCase(ContentAlignment.BottomCenter, 50.1f, 400.4f)]
            [TestCase(ContentAlignment.BottomRight, 100.2f, 400.4f)]
            public void Returns_Relative_Point(ContentAlignment alignment, float expectedX, float expectedY)
            {
                var point = new SizeF(100.2f, 400.4f).GetPoint(alignment);

                point.X.Should().Be(expectedX);
                point.Y.Should().Be(expectedY);
            }
        }

        public class AlignMethod : SizeFExtensionsTests
        {
            [TestCase(ContentAlignment.TopLeft, 0, 0)]
            [TestCase(ContentAlignment.TopCenter, 200.1f, 0)]
            [TestCase(ContentAlignment.TopRight, 400.2f, 0)]
            [TestCase(ContentAlignment.MiddleLeft, 0, 90.2f)]
            [TestCase(ContentAlignment.MiddleCenter, 200.1f, 90.2f)]
            [TestCase(ContentAlignment.MiddleRight, 400.2f, 90.2f)]
            [TestCase(ContentAlignment.BottomLeft, 0, 180.4f)]
            [TestCase(ContentAlignment.BottomCenter, 200.1f, 180.4f)]
            [TestCase(ContentAlignment.BottomRight, 400.2f, 180.4f)]
            public void Returns_The_Aligned_Rectangle(ContentAlignment alignment, float expectedRectX, float expectedRectY)
            {
                var outer = new SizeF(500.4f, 300.8f);
                var inner = new SizeF(100.2f, 120.4f);
                var centeredRectangle = outer.Align(inner, alignment);

                centeredRectangle.X.Should().Be(expectedRectX);
                centeredRectangle.Y.Should().Be(expectedRectY);
            }
        }
    }
}