using Session_09_Assignment;
using System;
using Xunit;

namespace Session09_AssignmentTests
{
    public class FineCalculatorTests
    {
        private readonly FineCalculator _calculator;

        public FineCalculatorTests()
        {
            _calculator = new FineCalculator();
        }

        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            // Arrange
            int a = 5;
            int b = 3;

            // Act
            var result = _calculator.Add(a, b);

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void Add_ShouldReturnNotEqual()
        {
            // Arrange
            int a = 5;
            int b = 3;

            // Act
            var result = _calculator.Add(a, b);

            // Assert
            Assert.NotEqual(10, result);
        }

        [Fact]
        public void Subtract_ShouldReturnCorrectDifference()
        {
            // Arrange
            int a = 10;
            int b = 4;

            // Act
            var result = _calculator.Subtract(a, b);

            // Assert
            Assert.Equal(6, result);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(4, 5, 20)]
        [InlineData(-2, 3, -6)]
        public void Multiply_ShouldReturnCorrectResult(int a, int b, int expected)
        {
            // Act
            var result = _calculator.Multiply(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 3, 10)]
        [InlineData(4, 5, 15)]
        [InlineData(-2, 3, 6)]
        public void Multiply_ShouldReturnNotEqual(int a, int b, int expected)
        {
            // Act
            var result = _calculator.Multiply(a, b);

            // Assert
            Assert.NotEqual(expected, result);
        }

        [Fact]
        public void Divide_ByZero_ShouldThrowException()
        {
            // Arrange
            int a = 12;
            int b = 0;

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() =>
            {
                return _calculator.Divide(a, b);
            });
        }
    }
}
