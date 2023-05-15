using System.Drawing;
using FluentAssertions;
using FluentStructures.Drawing;

namespace FluentStructures.Tests.Drawing
{
    public class RectangleExtensionsTests
    {
        private readonly Rectangle _rect = new(1, 2, 3, 4);

        public class AbsoluteWithMethods : RectangleExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Set_X()
            {
                var rect = _rect.WithX(10);

                rect.X.Should().Be(10);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Y()
            {
                var rect = _rect.WithY(10);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(10);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Width()
            {
                var rect = _rect.WithWidth(10);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(10);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Height()
            {
                var rect = _rect.WithHeight(10);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(10);
            }

            [Test]
            public void Can_Be_Used_To_Set_The_Location()
            {
                var rect = _rect.WithLocation(10, 20);

                rect.X.Should().Be(10);
                rect.Y.Should().Be(20);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_The_Location_2()
            {
                var rect = _rect.WithLocation(new Point(10, 20));

                rect.X.Should().Be(10);
                rect.Y.Should().Be(20);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_The_Size()
            {
                var rect = _rect.WithSize(10, 20);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(10);
                rect.Height.Should().Be(20);
            }

            [Test]
            public void Can_Be_Used_To_Set_The_Size_2()
            {
                var rect = _rect.WithSize(new Size(10, 20));

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(10);
                rect.Height.Should().Be(20);
            }

            [Test]
            public void Can_Be_Used_To_Set_Left()
            {
                var rect = _rect.WithLeft(10);

                rect.X.Should().Be(10);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Top()
            {
                var rect = _rect.WithTop(10);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(10);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Right_By_Moving()
            {
                var rect = _rect.WithRight(10, ShapeAdjustment.Move);

                rect.X.Should().Be(10 - 3); // new right - width
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Right_By_Resizing()
            {
                var rect = _rect.WithRight(10, ShapeAdjustment.Resize);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(10 - 1); // right - left
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Bottom_By_Moving()
            {
                var rect = _rect.WithBottom(10, ShapeAdjustment.Move);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(10 - 4); // new bottom - height
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Bottom_By_Resizing()
            {
                var rect = _rect.WithBottom(10, ShapeAdjustment.Resize);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(10 - 2); // bottom - top
            }

            [Test]
            public void Can_Be_Chained()
            {
                var rect = _rect.WithX(10).WithHeight(11);

                rect.X.Should().Be(10);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(11);
            }
        }

        public class ModifyingWithMethods : RectangleExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Set_X()
            {
                var rect = _rect.WithX(x => x + 10);

                rect.X.Should().Be(1 + 10);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Y()
            {
                var rect = _rect.WithY(y => y + 10);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2 + 10);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Width()
            {
                var rect = _rect.WithWidth(w => w + 10);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3 + 10);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Height()
            {
                var rect = _rect.WithHeight(h => h + 10);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4 + 10);
            }

            [Test]
            public void Can_Be_Used_To_Set_The_Location()
            {
                var rect = _rect.WithLocation(l => new Point(l.X + 10, l.Y + 20));

                rect.X.Should().Be(1 + 10);
                rect.Y.Should().Be(2 + 20);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_The_Size()
            {
                var rect = _rect.WithSize(s => new Size(s.Width + 10, s.Height + 20));

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3 + 10);
                rect.Height.Should().Be(4 + 20);
            }

            [Test]
            public void Can_Be_Used_To_Set_Left()
            {
                var rect = _rect.WithLeft(l => l + 10);

                rect.X.Should().Be(1 + 10);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Top()
            {
                var rect = _rect.WithTop(t => t + 10);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2 + 10);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Right_By_Moving()
            {
                var rect = _rect.WithRight(r => r + 10, ShapeAdjustment.Move);

                rect.X.Should().Be(1 + 10);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Right_By_Resizing()
            {
                var rect = _rect.WithRight(r => r + 10, ShapeAdjustment.Resize);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3 + 10); // right - left
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Bottom_By_Moving()
            {
                var rect = _rect.WithBottom(b => b + 10, ShapeAdjustment.Move);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2 + 10);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Set_Bottom_By_Resizing()
            {
                var rect = _rect.WithBottom(b => b + 10, ShapeAdjustment.Resize);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4 + 10);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var rect = _rect.WithX(x => x + 10).WithHeight(h => h + 10);

                rect.X.Should().Be(1 + 10);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4 + 10);
            }
        }

        public class AddMethods : RectangleExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Add_X()
            {
                var rect = _rect.AddX(10);

                rect.X.Should().Be(1 + 10);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Add_Y()
            {
                var rect = _rect.AddY(10);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2 + 10);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Add_Width()
            {
                var rect = _rect.AddWidth(10);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3 + 10);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Add_Height()
            {
                var rect = _rect.AddHeight(10);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4 + 10);
            }

            [Test]
            public void Can_Be_Used_To_Add_Left()
            {
                var rect = _rect.AddLeft(10);

                rect.X.Should().Be(1 + 10);
                rect.Y.Should().Be(2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Used_To_Add_Top()
            {
                var rect = _rect.AddTop(10);

                rect.X.Should().Be(1);
                rect.Y.Should().Be(2 + 10);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var rect = _rect.AddX(10).AddHeight(10).AddLeft(1).AddTop(2);

                rect.X.Should().Be(1 + 10 + 1);
                rect.Y.Should().Be(2 + 2);
                rect.Width.Should().Be(3);
                rect.Height.Should().Be(4 + 10);
            }
        }

        public class GetPointMethod : RectangleExtensionsTests
        {
            [TestCase(ContentAlignment.TopLeft, 33 + 0, 66 + 0)]
            [TestCase(ContentAlignment.TopCenter, 33 + 50, 66 + 0)]
            [TestCase(ContentAlignment.TopRight, 33 + 100, 66 + 0)]
            [TestCase(ContentAlignment.MiddleLeft, 33 + 0, 66 + 200)]
            [TestCase(ContentAlignment.MiddleCenter, 33 + 50, 66 + 200)]
            [TestCase(ContentAlignment.MiddleRight, 33 + 100, 66 + 200)]
            [TestCase(ContentAlignment.BottomLeft, 33 + 0, 66 + 400)]
            [TestCase(ContentAlignment.BottomCenter, 33 + 50, 66 + 400)]
            [TestCase(ContentAlignment.BottomRight, 33 + 100, 66 + 400)]
            public void Returns_Relative_Point(ContentAlignment alignment, int expectedX, int expectedY)
            {
                var point = new Rectangle(33, 66, 100, 400).GetPoint(alignment);

                point.X.Should().Be(expectedX);
                point.Y.Should().Be(expectedY);
            }
        }

        public class AlignMethod : RectangleExtensionsTests
        {
            /// <summary>
            /// Calculate the expected values without X and Y offset
            /// (easier to calculate for hoomans writing the test)
            /// </summary>
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
                var outer = new Rectangle(100, 120, 500, 300);
                var inner = new Size(100, 120);
                var centeredRectangle = outer.Align(inner, alignment);

                centeredRectangle.X.Should().Be(100 + expectedRectX);
                centeredRectangle.Y.Should().Be(120 + expectedRectY);
            }

            [Test]
            public void Returns_The_Same_Rectangle_As_The_Parent_If_Centered_And_Of_The_Same_Size()
            {
                var rect = new Rectangle(10, 20, 400, 300);
                var centeredRectangle = rect.Align(rect, ContentAlignment.MiddleCenter);

                centeredRectangle.X.Should().Be(10);
                centeredRectangle.Y.Should().Be(20);
                centeredRectangle.Width.Should().Be(400);
                centeredRectangle.Height.Should().Be(300);
            }

            [Test]
            public void Returns_Oversized_Rectangles_With_Negative_Location()
            {
                var rect = new Rectangle(10, 20, 400, 300);
                var biggerRect = new Rectangle(0, 0, 800, 600);
                var centeredRectangle = rect.Align(biggerRect, ContentAlignment.MiddleCenter);

                centeredRectangle.X.Should().Be(-190); // 10 + ((400 - 800) / 2)
                centeredRectangle.Y.Should().Be(-130);
                centeredRectangle.Width.Should().Be(800);
                centeredRectangle.Height.Should().Be(600);
            }
        }
    }
}