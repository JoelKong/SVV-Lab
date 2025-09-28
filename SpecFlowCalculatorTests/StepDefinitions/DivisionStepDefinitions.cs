using lab1;
using NUnit.Framework;
using Reqnroll;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class DivisionStepDefinitions
    {
        private readonly CalculatorContext _context;

        public DivisionStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press divide")]
        public void WhenIHaveEnteredAndIntoTheCalculatorAndPressDivide(double p0, double p1)
        {
            try
            {
                _context.Result = _context.Calculator.Divide(p0, p1);
                _context.Exception = null;
            }
            catch (System.Exception ex)
            {
                _context.Exception = ex;
            }
        }

        [Then(@"the division result should be (.*)")]
        public void ThenTheDivisionResultShouldBe(double expectedResult)
        {
            Assert.That(_context.Result, Is.EqualTo(expectedResult));
        }

        [Then(@"the division result equals positive_infinity")]
        public void ThenTheDivisionResultEqualsPositiveInfinity()
        {
            Assert.That(_context.Result, Is.EqualTo(double.PositiveInfinity));
        }

        [Then(@"the calculator should throw an exception")]
        public void ThenTheCalculatorShouldThrowAnException()
        {
            Assert.That(_context.Exception, Is.Not.Null);
            Assert.That(_context.Exception, Is.TypeOf<System.ArgumentException>());
        }
    }
}