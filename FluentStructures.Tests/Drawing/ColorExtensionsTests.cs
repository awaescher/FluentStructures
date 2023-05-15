using System.Drawing;
using FluentAssertions;
using FluentStructures.Drawing;

namespace FluentStructures.Tests.Drawing
{
    public class ColorExtensionsTests
    {
        private readonly Color _color = Color.FromArgb(alpha: 10, red: 20, green: 30, blue: 40);

        public class AbsoluteWithMethods : ColorExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Set_Alpha()
            {
                var color = _color.WithAlpha(100);

                color.A.Should().Be(100);
                color.R.Should().Be(20);
                color.G.Should().Be(30);
                color.B.Should().Be(40);
            }

            [Test]
            public void Can_Be_Used_To_Set_Red()
            {
                var color = _color.WithRed(100);

                color.A.Should().Be(10);
                color.R.Should().Be(100);
                color.G.Should().Be(30);
                color.B.Should().Be(40);
            }

            [Test]
            public void Can_Be_Used_To_Set_Green()
            {
                var color = _color.WithGreen(100);

                color.A.Should().Be(10);
                color.R.Should().Be(20);
                color.G.Should().Be(100);
                color.B.Should().Be(40);
            }

            [Test]
            public void Can_Be_Used_To_Set_Blue()
            {
                var color = _color.WithBlue(100);

                color.A.Should().Be(10);
                color.R.Should().Be(20);
                color.G.Should().Be(30);
                color.B.Should().Be(100);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var color = _color.WithAlpha(100).WithRed(120);

                color.A.Should().Be(100);
                color.R.Should().Be(120);
                color.G.Should().Be(30);
                color.B.Should().Be(40);
            }
        }

        public class ModifyingWithMethods : ColorExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Set_Alpha()
            {
                var color = _color.WithAlpha(a => a + 100);

                color.A.Should().Be(10 + 100);
                color.R.Should().Be(20);
                color.G.Should().Be(30);
                color.B.Should().Be(40);
            }

            [Test]
            public void Can_Be_Used_To_Set_Red()
            {
                var color = _color.WithRed(r => r + 100);

                color.A.Should().Be(10);
                color.R.Should().Be(20 + 100);
                color.G.Should().Be(30);
                color.B.Should().Be(40);
            }

            [Test]
            public void Can_Be_Used_To_Set_Green()
            {
                var color = _color.WithGreen(g => g + 100);

                color.A.Should().Be(10);
                color.R.Should().Be(20);
                color.G.Should().Be(30 + 100);
                color.B.Should().Be(40);
            }

            [Test]
            public void Can_Be_Used_To_Set_Blue()
            {
                var color = _color.WithBlue(b => b + 100);

                color.A.Should().Be(10);
                color.R.Should().Be(20);
                color.G.Should().Be(30);
                color.B.Should().Be(40 + 100);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var color = _color.WithAlpha(a => a + 100).WithRed(r => r + 120);

                color.A.Should().Be(10 + 100);
                color.R.Should().Be(20 + 120);
                color.G.Should().Be(30);
                color.B.Should().Be(40);
            }
        }

        public class AddMethods : ColorExtensionsTests
        {
            [Test]
            public void Can_Be_Used_To_Add_Alpha()
            {
                var color = _color.AddAlpha(100);

                color.A.Should().Be(10 + 100);
                color.R.Should().Be(20);
                color.G.Should().Be(30);
                color.B.Should().Be(40);
            }

            [Test]
            public void Can_Be_Used_To_Add_Red()
            {
                var color = _color.AddRed(100);

                color.A.Should().Be(10);
                color.R.Should().Be(20 + 100);
                color.G.Should().Be(30);
                color.B.Should().Be(40);
            }

            [Test]
            public void Can_Be_Used_To_Add_Green()
            {
                var color = _color.AddGreen(100);

                color.A.Should().Be(10);
                color.R.Should().Be(20);
                color.G.Should().Be(30 + 100);
                color.B.Should().Be(40);
            }

            [Test]
            public void Can_Be_Used_To_Add_Blue()
            {
                var color = _color.AddBlue(100);

                color.A.Should().Be(10);
                color.R.Should().Be(20);
                color.G.Should().Be(30);
                color.B.Should().Be(40 + 100);
            }

            [Test]
            public void Can_Be_Chained()
            {
                var color = _color.AddAlpha(100).AddRed(120);

                color.A.Should().Be(10 + 100);
                color.R.Should().Be(20 + 120);
                color.G.Should().Be(30);
                color.B.Should().Be(40);
            }
        }
    }
}