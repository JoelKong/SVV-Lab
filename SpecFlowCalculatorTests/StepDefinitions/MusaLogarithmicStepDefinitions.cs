using lab1;
using NUnit.Framework;
using Reqnroll;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class MusaLogarithmicStepDefinitions
    {
        private readonly CalculatorContext _context;

        public MusaLogarithmicStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        [When(@"I have entered (.*) and (.*) and (.*) into the calculator and press Musa failure intensity")]
        public void WhenIHaveEnteredThreeValuesAndPressMusaFailureIntensity(double initialIntensity, double decayParameter, double executionTime)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateMusaLogFailureIntensity(initialIntensity, decayParameter, executionTime);
                _context.Exception = null;
            }
            catch (System.Exception ex)
            {
                _context.Exception = ex;
            }
        }

        [When(@"I have entered (.*) and (.*) and (.*) into the calculator and press Musa expected failures")]
        public void WhenIHaveEnteredThreeValuesAndPressMusaExpectedFailures(double initialIntensity, double decayParameter, double executionTime)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateMusaLogExpectedFailures(initialIntensity, decayParameter, executionTime);
                _context.Exception = null;
            }
            catch (System.Exception ex)
            {
                _context.Exception = ex;
            }
        }

        [Then(@"the logarithmic result should be ""(.*)""")]
        public void ThenTheLogarithmicResultShouldBe(string expectedResult)
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

        [Then(@"the calculator should display a logarithmic error message ""(.*)""")]
        public void ThenTheCalculatorShouldDisplayALogarithmicErrorMessage(string expectedMessage)
        {
            Assert.That(_context.Exception, Is.Not.Null);
            Assert.That(_context.Exception, Is.TypeOf<System.ArgumentException>());
            Assert.That(_context.Exception.Message, Is.EqualTo(expectedMessage));
        }
    }
}