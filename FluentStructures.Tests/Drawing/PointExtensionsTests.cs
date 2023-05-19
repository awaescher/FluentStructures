using System.Drawing;
using FluentAssertions;
using FluentStructures.Drawing;

namespace FluentStructures.Tests.Drawing
{
    public class PointExtensionsTests
    {
        private readonly Point _point = new(1, 2);

        public class AbsoluteWithMethods : PointExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Set_Width()
            {
                var point = _point.WithX(10);

                point.X.Should().Be(10);
                point.Y.Should().Be(2);
            }

            [Test]
            public void Can_Be_Used_To_Set_Height()
            {
                var point = _point.WithY(10);

                point.X.Should().Be(1);
                point.Y.Should().Be(10);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var point = _point.WithX(10).WithY(11);

                point.X.Should().Be(10);
                point.Y.Should().Be(11);
            }
        }

        public class ModifyingWithMethods : PointExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Set_Width()
            {
                var point = _point.WithX(x => x + 10);

                point.X.Should().Be(1 + 10);
                point.Y.Should().Be(2);
            }

            [Test]
            public void Can_Be_Used_To_Set_Height()
            {
                var point = _point.WithY(y => y + 10);

                point.X.Should().Be(1);
                point.Y.Should().Be(2 + 10);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var point = _point.WithX(x => x + 10).WithY(y => y + 11);

                point.X.Should().Be(1 + 10);
                point.Y.Should().Be(2 + 11);
            }
        }

        public class WithAdditionalMethods : PointExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Add_X()
            {
                var point = _point.WithAdditionalX(10);

                point.X.Should().Be(11);
                point.Y.Should().Be(2);
            }

            [Test]
            public void Can_Be_Used_To_Set_Y()
            {
                var point = _point.WithAdditionalY(10);

                point.X.Should().Be(1);
                point.Y.Should().Be(12);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var point = _point.WithAdditionalX(10).WithAdditionalY(11);

                point.X.Should().Be(11);
                point.Y.Should().Be(13);
            }
        }
    }
}