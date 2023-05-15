using System.Drawing;
using FluentAssertions;
using FluentStructures.Drawing;

namespace FluentStructures.Tests.Drawing
{
    public class PointFExtensionsTests
    {
        private readonly PointF _point = new(1.1f, 2.2f);

        public class AbsoluteWithMethods : PointFExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Set_Width()
            {
                var point = _point.WithX(10.1f);

                point.X.Should().Be(10.1f);
                point.Y.Should().Be(2.2f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Height()
            {
                var point = _point.WithY(10.1f);

                point.X.Should().Be(1.1f);
                point.Y.Should().Be(10.1f);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var point = _point.WithX(10.1f).WithY(11.1f);

                point.X.Should().Be(10.1f);
                point.Y.Should().Be(11.1f);
            }
        }

        public class ModifyingWithMethods : PointFExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Set_Width()
            {
                var point = _point.WithX(x => x + 10.1f);

                point.X.Should().Be(1.1f + 10.1f);
                point.Y.Should().Be(2.2f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Height()
            {
                var point = _point.WithY(y => y + 10.1f);

                point.X.Should().Be(1.1f);
                point.Y.Should().Be(2.2f + 10.1f);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var point = _point.WithX(x => x + 10.1f).WithY(y => y + 11.1f);

                point.X.Should().Be(1.1f + 10.1f);
                point.Y.Should().Be(2.2f + 11.1f);
            }
        }

        public class AddMethods : PointFExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Add_X()
            {
                var point = _point.AddX(10.1f);

                point.X.Should().Be(1.1f + 10.1f);
                point.Y.Should().Be(2.2f);
            }

            [Test]
            public void Can_Be_Used_To_Set_Y()
            {
                var point = _point.AddY(10.1f);

                point.X.Should().Be(1.1f);
                point.Y.Should().Be(2.2f + 10.1f);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var point = _point.AddX(10.1f).AddY(11.1f);

                point.X.Should().Be(1.1f + 10.1f);
                point.Y.Should().Be(2.2f + 11.1f);
            }
        }
    }
}