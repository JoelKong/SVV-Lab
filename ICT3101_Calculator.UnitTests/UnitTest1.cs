using lab1;

namespace ICT3101_Calculator.UnitTests
{
    public class CalculatorTests
    {
        private Calculator _calculator;
        [SetUp]
        public void Setup()
        {
            // Arrange
            _calculator = new Calculator();
        }

        #region Add Tests
        [Test]
        public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
        {
            // Act
            double result = _calculator.Add(10, 20);
            // Assert
            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void Add_WhenAddingZeros_ResultIsZero()
        {
            // Act
            double result = _calculator.Add(0, 0);
            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Add_WhenAddingNegativeNumbers_ResultEqualToSum()
        {
            // Act
            double result = _calculator.Add(-5, -10);
            // Assert
            Assert.That(result, Is.EqualTo(-15));
        }

        [Test]
        public void Add_WhenAddingPositiveAndNegative_ResultEqualToSum()
        {
            // Act
            double result = _calculator.Add(15, -5);
            // Assert
            Assert.That(result, Is.EqualTo(10));
        }
        #endregion

        #region Subtract Tests
        [Test]
        public void Subtract_WhenSubtractingTwoNumbers_ResultEqualToDifference()
        {
            // Act
            double result = _calculator.Subtract(20, 10);
            // Assert
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Subtract_WhenSubtractingFromZero_ResultIsNegative()
        {
            // Act
            double result = _calculator.Subtract(0, 5);
            // Assert
            Assert.That(result, Is.EqualTo(-5));
        }

        [Test]
        public void Subtract_WhenSubtractingZero_ResultIsOriginal()
        {
            // Act
            double result = _calculator.Subtract(10, 0);
            // Assert
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Subtract_WhenSubtractingNegativeNumbers_ResultEqualToDifference()
        {
            // Act
            double result = _calculator.Subtract(-5, -10);
            // Assert
            Assert.That(result, Is.EqualTo(5));
        }
        #endregion

        #region Multiply Tests
        [Test]
        public void Multiply_WhenMultiplyingTwoNumbers_ResultEqualToProduct()
        {
            // Act
            double result = _calculator.Multiply(5, 4);
            // Assert
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Multiply_WhenMultiplyingByZero_ResultIsZero()
        {
            // Act
            double result = _calculator.Multiply(10, 0);
            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Multiply_WhenMultiplyingZeroByZero_ResultIsZero()
        {
            // Act
            double result = _calculator.Multiply(0, 0);
            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Multiply_WhenMultiplyingNegativeNumbers_ResultIsPositive()
        {
            // Act
            double result = _calculator.Multiply(-5, -4);
            // Assert
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Multiply_WhenMultiplyingPositiveAndNegative_ResultIsNegative()
        {
            // Act
            double result = _calculator.Multiply(5, -4);
            // Assert
            Assert.That(result, Is.EqualTo(-20));
        }
        #endregion

        #region Divide Tests
        [Test]
        public void Divide_WhenDividingTwoNumbers_ResultEqualToQuotient()
        {
            // Act
            double result = _calculator.Divide(20, 4);
            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Divide_WhenDividingZeroByZero_ResultIsOne()
        {
            // Act
            double result = _calculator.Divide(0, 0);
            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Divide_WhenDividingZeroByNumber_ResultIsZero()
        {
            // Act
            double result = _calculator.Divide(0, 10);
            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Divide_WhenDividingByZero_ResultIsPositiveInfinity()
        {
            // Act
            double result = _calculator.Divide(10, 0);
            // Assert
            Assert.That(result, Is.EqualTo(double.PositiveInfinity));
        }

        [Test]
        public void Divide_WhenDividingNegativeNumbers_ResultIsPositive()
        {
            // Act
            double result = _calculator.Divide(-20, -4);
            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Divide_WhenDividingPositiveByNegative_ResultIsNegative()
        {
            // Act
            double result = _calculator.Divide(20, -4);
            // Assert
            Assert.That(result, Is.EqualTo(-5));
        }
        #endregion

        #region Factorial Tests
        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 6)]
        [TestCase(4, 24)]
        [TestCase(5, 120)]
        [TestCase(10, 3628800)]
        public void Factorial_WhenCalculatingValidFactorials_ResultIsCorrect(double input, double expected)
        {
            // Act
            double result = _calculator.Factorial(input);
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-10)]
        public void Factorial_WhenCalculatingNegativeNumbers_ThrowsArgumentException(double input)
        {
            // Act & Assert
            Assert.That(() => _calculator.Factorial(input), Throws.ArgumentException);
        }

        [Test]
        [TestCase(2.5)]
        [TestCase(3.7)]
        [TestCase(10.1)]
        public void Factorial_WhenCalculatingNonIntegers_ThrowsArgumentException(double input)
        {
            // Act & Assert
            Assert.That(() => _calculator.Factorial(input), Throws.ArgumentException);
        }

        [Test]
        public void Factorial_WhenNumberTooLarge_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.That(() => _calculator.Factorial(171), Throws.ArgumentException);
        }
        #endregion

        #region Basic Musa Model Tests
        [Test]
        public void CalculateCurrentFailureIntensity_WithValidParameters_ReturnsCorrectResult()
        {
            // Act
            double result = _calculator.CalculateCurrentFailureIntensity(100, 10, 50);
            // Assert
            Assert.That(result, Is.EqualTo(45).Within(0.001));
        }

        [Test]
        public void CalculateCurrentFailureIntensity_WithZeroCurrentFailures_ReturnsInitialIntensity()
        {
            // Act
            double result = _calculator.CalculateCurrentFailureIntensity(200, 0, 30);
            // Assert
            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void CalculateCurrentFailureIntensity_WithAllFailures_ReturnsZero()
        {
            // Act
            double result = _calculator.CalculateCurrentFailureIntensity(50, 50, 25);
            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase(-100, 10, 50)]
        [TestCase(100, -10, 50)]
        [TestCase(100, 10, -50)]
        public void CalculateCurrentFailureIntensity_WithNegativeParameters_ThrowsArgumentException(double totalFailures, double currentFailures, double initialIntensity)
        {
            // Act & Assert
            Assert.That(() => _calculator.CalculateCurrentFailureIntensity(totalFailures, currentFailures, initialIntensity), 
                Throws.ArgumentException.With.Message.EqualTo("All parameters must be non-negative"));
        }

        [Test]
        public void CalculateAverageExpectedFailures_WithValidParameters_ReturnsCorrectResult()
        {
            // Act
            double result = _calculator.CalculateAverageExpectedFailures(200, 10, 50);
            // Assert
            Assert.That(result, Is.EqualTo(86.466).Within(0.001));
        }

        [Test]
        public void CalculateAverageExpectedFailures_WithZeroTime_ReturnsZero()
        {
            // Act
            double result = _calculator.CalculateAverageExpectedFailures(100, 5, 0);
            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase(-200, 10, 50)]
        [TestCase(200, -10, 50)]
        [TestCase(200, 10, -50)]
        public void CalculateAverageExpectedFailures_WithNegativeParameters_ThrowsArgumentException(double totalFailures, double initialIntensity, double executionTime)
        {
            // Act & Assert
            Assert.That(() => _calculator.CalculateAverageExpectedFailures(totalFailures, initialIntensity, executionTime), 
                Throws.ArgumentException.With.Message.EqualTo("All parameters must be non-negative"));
        }
        #endregion
    }
}