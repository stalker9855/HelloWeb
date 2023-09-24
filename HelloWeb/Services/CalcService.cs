using HelloWeb.Interfaces;

namespace HelloWeb.Services
{
    public class CalcService : ICalc
    {
        public double num1;
        public double num2;

        public double Divide(double num1, double num2)
        {
            if (num2 != 0)
            {
                return num1 / num2;
            }
            else throw new DivideByZeroException("Error: 0 divide");

        }
        public double Multiply(double num1, double num2) => num1 * num2;
        public double Addition(double num1, double num2) => num1 + num2;
        public double Substract(double num1, double num2) => num1 - num2;
    }
}