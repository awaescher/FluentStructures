using System.Drawing;
using FluentAssertions;
using FluentStructures.Drawing;

namespace FluentStructures.Tests.Drawing
{
    public class RectangleFExtensionsTests
    {
        private readonly RectangleF _rect = new(1.1f, 2.2f, 3.3f, 4.4f);

        public class AbsoluteWithMethods : RectangleFExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Set_X()
            {
                var rect = _rect.WithX(10.1f);

                rect.X.Should().Be(10.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Y()
            {
                var rect = _rect.WithY(10.1f);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(10.1f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Width()
            {
                var rect = _rect.WithWidth(10.1f);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(10.1f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Height()
            {
                var rect = _rect.WithHeight(10.1f);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(10.1f);
            }

            [Test]
            public void Can_Be_Used_To_Set_The_Location()
            {
                var rect = _rect.WithLocation(10.1f, 20.1f);

                rect.X.Should().Be(10.1f);
                rect.Y.Should().Be(20.1f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_The_Location_2()
            {
                var rect = _rect.WithLocation(new PointF(10.1f, 20.1f));

                rect.X.Should().Be(10.1f);
                rect.Y.Should().Be(20.1f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_The_Size()
            {
                var rect = _rect.WithSize(10.1f, 20.1f);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(10.1f);
                rect.Height.Should().Be(20.1f);
            }

            [Test]
            public void Can_Be_Used_To_Set_The_Size_2()
            {
                var rect = _rect.WithSize(new SizeF(10.1f, 20.1f));

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(10.1f);
                rect.Height.Should().Be(20.1f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Left()
            {
                var rect = _rect.WithLeft(10.1f);

                rect.X.Should().Be(10.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Top()
            {
                var rect = _rect.WithTop(10.1f);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(10.1f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Right_By_Moving()
            {
                var rect = _rect.WithRight(10.1f, ShapeAdjustment.Move);

                rect.X.Should().Be(10.1f - 3.3f); // new right - width
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Right_By_Resizing()
            {
                var rect = _rect.WithRight(10.1f, ShapeAdjustment.Resize);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(10.1f - 1.1f); // right - left
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Bottom_By_Moving()
            {
                var rect = _rect.WithBottom(10.1f, ShapeAdjustment.Move);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().BeApproximately(10.1f - 4.4f, 0.001f); // new bottom - height
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Bottom_By_Resizing()
            {
                var rect = _rect.WithBottom(10.1f, ShapeAdjustment.Resize);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().BeApproximately(10.1f - 2.2f, 0.001f); // bottom - top
            }

            [Test]
            public void Can_Be_Chained()
            {
                var rect = _rect.WithX(10.1f).WithHeight(11.1f);

                rect.X.Should().Be(10.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(11.1f);
            }
        }

        public class ModifyingWithMethods : RectangleFExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Set_X()
            {
                var rect = _rect.WithX(x => x + 10.1f);

                rect.X.Should().Be(1.1f + 10.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Y()
            {
                var rect = _rect.WithY(y => y + 10.1f);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f + 10.1f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Width()
            {
                var rect = _rect.WithWidth(w => w + 10.1f);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f + 10.1f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Height()
            {
                var rect = _rect.WithHeight(h => h + 10.1f);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f + 10.1f);
            }

            [Test]
            public void Can_Be_Used_To_Set_The_Location()
            {
                var rect = _rect.WithLocation(l => new PointF(l.X + 10.1f, l.Y + 20.1f));

                rect.X.Should().Be(1.1f + 10.1f);
                rect.Y.Should().Be(2.2f + 20.1f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_The_Size()
            {
                var rect = _rect.WithSize(s => new SizeF(s.Width + 10.1f, s.Height + 20.1f));

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f + 10.1f);
                rect.Height.Should().Be(4.4f + 20.1f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Left()
            {
                var rect = _rect.WithLeft(l => l + 10.1f);

                rect.X.Should().Be(1.1f + 10.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Top()
            {
                var rect = _rect.WithTop(t => t + 10.1f);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f + 10.1f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Right_By_Moving()
            {
                var rect = _rect.WithRight(r => r + 10.1f, ShapeAdjustment.Move);

                rect.X.Should().Be(1.1f + 10.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Right_By_Resizing()
            {
                var rect = _rect.WithRight(r => r + 10.1f, ShapeAdjustment.Resize);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f + 10.1f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Bottom_By_Moving()
            {
                var rect = _rect.WithBottom(b => b + 10.1f, ShapeAdjustment.Move);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f + 10.1f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Bottom_By_Resizing()
            {
                var rect = _rect.WithBottom(b => b + 10.1f, ShapeAdjustment.Resize);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f + 10.1f);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var rect = _rect.WithX(x => x + 10.1f).WithHeight(h => h + 10.1f);

                rect.X.Should().Be(1.1f + 10.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f + 10.1f);
            }
        }

        public class WithAdditionalMethods : RectangleFExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Add_X()
            {
                var rect = _rect.WithAdditionalX(10.1f);

                rect.X.Should().Be(1.1f + 10.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Add_Y()
            {
                var rect = _rect.WithAdditionalY(10.1f);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f + 10.1f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Add_Width()
            {
                var rect = _rect.WithAdditionalWidth(10.1f);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f + 10.1f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Add_Height()
            {
                var rect = _rect.WithAdditionalHeight(10.1f);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f + 10.1f);
            }

            [Test]
            public void Can_Be_Used_To_Add_Left()
            {
                var rect = _rect.WithAdditionalLeft(10.1f);

                rect.X.Should().Be(1.1f + 10.1f);
                rect.Y.Should().Be(2.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Used_To_Add_Top()
            {
                var rect = _rect.WithAdditionalTop(10.1f);

                rect.X.Should().Be(1.1f);
                rect.Y.Should().Be(2.2f + 10.1f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var rect = _rect.WithAdditionalX(10.1f).WithAdditionalHeight(10.1f).WithAdditionalLeft(1.1f).WithAdditionalTop(1.2f);

                rect.X.Should().Be(1.1f + 10.1f + 1.1f);
                rect.Y.Should().Be(2.2f + 1.2f);
                rect.Width.Should().Be(3.3f);
                rect.Height.Should().Be(4.4f + 10.1f);
            }
        }

        public class GetPointMethod : RectangleFExtensionsTests
        {
            [TestCase(ContentAlignment.TopLeft, 33.1f + 0, 66.2f + 0)]
            [TestCase(ContentAlignment.TopCenter, 33.1f + 50.1f, 66.2f + 0)]
            [TestCase(ContentAlignment.TopRight, 33.1f + 100.2f, 66.2f + 0)]
            [TestCase(ContentAlignment.MiddleLeft, 33.1f + 0, 66.2f + 200.2f)]
            [TestCase(ContentAlignment.MiddleCenter, 33.1f + 50.1f, 66.2f + 200.2f)]
            [TestCase(ContentAlignment.MiddleRight, 33.1f + 100.2f, 66.2f + 200.2f)]
            [TestCase(ContentAlignment.BottomLeft, 33.1f + 0, 66.2f + 400.4f)]
            [TestCase(ContentAlignment.BottomCenter, 33.1f + 50.1f, 66.2f + 400.4f)]
            [TestCase(ContentAlignment.BottomRight, 33.1f + 100.2f, 66.2f + 400.4f)]
            public void Returns_Relative_Point(ContentAlignment alignment, float expectedX, float expectedY)
            {
                var point = new RectangleF(33.1f, 66.2f, 100.2f, 400.4f).GetPoint(alignment);

                point.X.Should().Be(expectedX);
                point.Y.Should().Be(expectedY);
            }
        }

        public class AlignMethod : RectangleFExtensionsTests
        {
            /// <summary>
            /// Calculate the expected values without X and Y offset
            /// (easier to calculate for hoomans writing the test)
            /// </summary>
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
                var outer = new RectangleF(100.5f, 120.7f, 500.4f, 300.8f);
                var inner = new SizeF(100.2f, 120.4f);
                var centeredRectangle = outer.Align(inner, alignment);

                centeredRectangle.X.Should().Be(100.5f + expectedRectX);
                centeredRectangle.Y.Should().Be(120.7f + expectedRectY);
            }

            [Test]
            public void Returns_The_Same_Rectangle_As_The_Parent_If_Centered_And_Of_The_Same_Size()
            {
                var rect = new RectangleF(10.1f, 20.2f, 400.3f, 300.4f);
                var centeredRectangle = rect.Align(rect, ContentAlignment.MiddleCenter);

                centeredRectangle.X.Should().Be(10.1f);
                centeredRectangle.Y.Should().Be(20.2f);
                centeredRectangle.Width.Should().Be(400.3f);
                centeredRectangle.Height.Should().Be(300.4f);
            }

            [Test]
            public void Returns_Oversized_Rectangles_With_Negative_Location()
            {
                var rect = new RectangleF(10.1f, 20.2f, 400.8f, 300.4f);
                var biggerRect = new RectangleF(0, 0, 800.4f, 600.2f);
                var centeredRectangle = rect.Align(biggerRect, ContentAlignment.MiddleCenter);

                centeredRectangle.X.Should().BeApproximately(-189.7f, 0.01f); // 10.1 + ((400.8 - 800.4) / 2)
                centeredRectangle.Y.Should().BeApproximately(-129.7f, 0.01f);
                centeredRectangle.Width.Should().Be(800.4f);
                centeredRectangle.Height.Should().Be(600.2f);
            }
        }
    }
}