using HelloWeb;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();
Company company = new Company
{
    cName = "TD",
    cDescription = "Description",
    cEmail = "ttd211s@outlol.com",
    cPhone = "+4172763821782",
    cWorkerks = 50
};

// Token Middlweare || 1g231
app.UseMiddleware<TokenMiddleware>();
app.MapGet("/", () => $"{company}");
app.MapGet("/randnum", () => $"\nRandom number (0 to 100): {company.RandomNumber()}");
app.Run();

