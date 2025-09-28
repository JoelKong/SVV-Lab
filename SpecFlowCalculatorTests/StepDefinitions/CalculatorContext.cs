using lab1;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    public class CalculatorContext
    {
        public Calculator Calculator { get; set; }
        public double Result { get; set; }
        public Exception Exception { get; set; }
    }
}