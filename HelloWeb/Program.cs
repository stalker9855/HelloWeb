using HelloWeb;
using HelloWeb.Controllers;
using HelloWeb.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddTransient<CalcService>();
builder.Services.AddTransient<TimeService>();
var app = builder.Build();
CalcController calculator = new CalcController();
TimeService timeService = new TimeService();
// Token Middlweare || 1g231
//app.UseMiddleware<TokenMiddleware>();
app.MapGet("/", async context =>
{
    await context.Response.WriteAsync(@"
<html>
    <head></head>
    <body>
        <h1>Calculator!</h1>
        <form method='post' action='/calculate'>
            <label for='num1'> First number: </label>
            <input name='num1' type='text'><br>
            <div>
                <input name='operation' type='radio' id='add' name='addition' value='+'> 
                <label for='add'>+</label>
                <input name='operation' type='radio' id='multi' name='multiply' value='*'> 
                <label for='multi'>*</label>
                <input name='operation' type='radio' id='substr' name='substract' value='-'> 
                <label for='substr'>-</label>
                <input name='operation' type='radio' id='divide' name='division' value='/'> 
                <label for='divide'>/</label>
            </div>
            <label for='num2'> Second number: </label>
            <input name='num2' type='text'><br>
            <div>
                <button type='submit'>Submit</button>
            </div>
        </form>
    </body>
</html>");
});
app.MapPost("/calculate", async context =>
{
    var operation = context.Request.Form["operation"];
    var num1 = Convert.ToDouble(context.Request.Form["num1"]);
    var num2 = Convert.ToDouble(context.Request.Form["num2"]);

    double result = 0;

    switch (operation)
    {
        case "+":
            result = calculator.Addition(num1, num2);
            break;
        case "-":
            result = calculator.Substract(num1, num2);
            Console.WriteLine(result);
            break;
        case "*":
            result = calculator.Multiply(num1, num2);
            break;
        case "/":
            result = calculator.Divide(num1, num2);
            break;
    }

    await context.Response.WriteAsync($"Result: {result}");
});

app.MapGet("/time", () =>
{
    return timeService.GetTime();
});
app.Run();

