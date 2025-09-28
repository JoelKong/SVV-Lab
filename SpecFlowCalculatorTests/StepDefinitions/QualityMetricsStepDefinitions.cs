using lab1;
using NUnit.Framework;
using Reqnroll;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class QualityMetricsStepDefinitions
    {
        private readonly CalculatorContext _context;

        public QualityMetricsStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press defect density")]
        public void WhenIHaveEnteredTwoValuesAndPressDefectDensity(double defects, double linesOfCode)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateDefectDensity(defects, linesOfCode);
                _context.Exception = null;
            }
            catch (System.Exception ex)
            {
                _context.Exception = ex;
            }
        }

        [When(@"I have entered (.*) and (.*) and (.*) into the calculator and press SSI calculation")]
        public void WhenIHaveEnteredThreeValuesAndPressSSICalculation(double currentSSI, double addedSSI, double deletedSSI)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateNewSSI(currentSSI, addedSSI, deletedSSI);
                _context.Exception = null;
            }
            catch (System.Exception ex)
            {
                _context.Exception = ex;
            }
        }

        [Then(@"the quality metrics result should be ""(.*)""")]
        public void ThenTheQualityMetricsResultShouldBe(string expectedResult)
        {
            if (double.TryParse(expectedResult, out double expected))
            {
                Assert.That(_context.Result, Is.EqualTo(expected).Within(0.001));
            }
            else
            {
                Assert.That(_context.Result.ToString(), Is.EqualTo(expectedResult));
            }
        }

        [Then(@"the calculator should display a quality metrics error message ""(.*)""")]
        public void ThenTheCalculatorShouldDisplayAQualityMetricsErrorMessage(string expectedMessage)
        {
            Assert.That(_context.Exception, Is.Not.Null);
            Assert.That(_context.Exception, Is.TypeOf<System.ArgumentException>());
            Assert.That(_context.Exception.Message, Is.EqualTo(expectedMessage));
        }
    }
}