using lab1;
using NUnit.Framework;
using Reqnroll;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorStepDefinitions
    {
        private readonly CalculatorContext _context;

        public UsingCalculatorStepDefinitions(CalculatorContext context)
        {
            _context = context;
        }

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            _context.Calculator = new Calculator();
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press add")]
        public void WhenIHaveEnteredAndIntoTheCalculator(double p0, double p1)
        {
            _context.Result = _context.Calculator.Add(p0, p1);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBeOnTheScreen(double p0)
        {
            Assert.That(_context.Result, Is.EqualTo(p0));
        }
    }
}