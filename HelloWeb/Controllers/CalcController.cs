using HelloWeb.Services;
using Microsoft.AspNetCore.Mvc;
namespace HelloWeb.Controllers
{
    public class CalcController : Controller
    {
        CalcService calcService = new CalcService();

        public double Addition(double num1, double num2)
        {
            return calcService.Addition(num1, num2);
        }
        public double Substract(double num1, double num2)
        {
            return calcService.Substract(num1, num2);
        }
        public double Divide(double num1, double num2)
        {
            return calcService.Divide(num1, num2);
        }
        public double Multiply(double num1, double num2)
        {
            return calcService.Multiply(num1, num2);
        }
    }
}
