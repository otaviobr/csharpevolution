namespace CsharpEvolution
{
    public class Calculator : ICalculator
    {
        public ArithmeticOperations ArithmeticOperations => new ArithmeticOperations();
    }
}
