using lab1;
using NUnit.Framework;
using Reqnroll;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class BasicReliabilityStepDefinitions
    {
        private readonly CalculatorContext _context;

        public BasicReliabilityStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        [When(@"I have entered (.*) and (.*) and (.*) into the calculator and press current failure intensity")]
        public void WhenIHaveEnteredThreeValuesAndPressCurrentFailureIntensity(double totalFailures, double currentFailures, double initialFailureIntensity)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateCurrentFailureIntensity(totalFailures, currentFailures, initialFailureIntensity);
                _context.Exception = null;
            }
            catch (System.Exception ex)
            {
                _context.Exception = ex;
            }
        }
//test
        [When(@"I have entered (.*) and (.*) and (.*) into the calculator and press average expected failures")]
        public void WhenIHaveEnteredThreeValuesAndPressAverageExpectedFailures(double totalFailures, double initialFailureIntensity, double executionTime)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateAverageExpectedFailures(totalFailures, initialFailureIntensity, executionTime);
                _context.Exception = null;
            }
            catch (System.Exception ex)
            {
                _context.Exception = ex;
            }
        }

        [Then(@"the reliability result should be ""(.*)""")]
        public void ThenTheReliabilityResultShouldBe(string expectedResult)
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

        [Then(@"the calculator should display a reliability error message ""(.*)""")]
        public void ThenTheCalculatorShouldDisplayAReliabilityErrorMessage(string expectedMessage)
        {
            Assert.That(_context.Exception, Is.Not.Null);
            Assert.That(_context.Exception, Is.TypeOf<System.ArgumentException>());
            Assert.That(_context.Exception.Message, Is.EqualTo(expectedMessage));
        }
    }
}