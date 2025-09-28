using lab1;
using NUnit.Framework;
using Reqnroll;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class AvailabilityStepDefinitions
    {
        private readonly CalculatorContext _context;

        public AvailabilityStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press MTBF")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressMTBF(double totalTime, double numberOfFailures)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateMTBF(totalTime, numberOfFailures);
                _context.Exception = null;
            }
            catch (System.Exception ex)
            {
                _context.Exception = ex;
            }
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press Availability")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressAvailability(double mtbf, double mttr)
        {
            try
            {
                _context.Result = _context.Calculator.CalculateAvailability(mtbf, mttr);
                _context.Exception = null;
            }
            catch (System.Exception ex)
            {
                _context.Exception = ex;
            }
        }

        [Then(@"the availability result should be ""(.*)""")]
        public void ThenTheAvailabilityResultShouldBe(string expectedResult)
        {
            if (double.TryParse(expectedResult, out double expected))
            {
                Assert.That(_context.Result, Is.EqualTo(expected).Within(0.000001));
            }
            else
            {
                Assert.That(_context.Result.ToString(), Is.EqualTo(expectedResult));
            }
        }

        [Then(@"the calculator should display an error message ""(.*)""")]
        public void ThenTheCalculatorShouldDisplayAnErrorMessage(string expectedMessage)
        {
            Assert.That(_context.Exception, Is.Not.Null);
            Assert.That(_context.Exception, Is.TypeOf<System.ArgumentException>());
            Assert.That(_context.Exception.Message, Is.EqualTo(expectedMessage));
        }
    }
}