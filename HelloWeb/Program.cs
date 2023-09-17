using HelloWeb;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
string[] configs = { "Configurations\\microsoft.json", "Configurations\\apple.ini", "Configurations\\google.xml" };
List<Company> companies = new List<Company>();

foreach (string config in configs)
{
    switch (Path.GetExtension(config))
    {
        case ".json":
            builder.Configuration.AddJsonFile(config);
             break;
        case ".xml":
            builder.Configuration.AddXmlFile(config);
            break;
        case ".ini":
            builder.Configuration.AddIniFile(config);
            break;
        default:
            break;
    }
    Company tempCompany = app.Configuration.Get<Company>();
    companies.Add(tempCompany);
}
builder.Configuration.AddJsonFile("Configurations\\about.json");
// Token Middlweare || 1g231
app.UseMiddleware<TokenMiddleware>();
app.Map("/", (IConfiguration appConfig) =>
{
    string companyName = "";
    int employees = 0;
    foreach (Company company in companies)
    {
        if (company.Employees > employees)
        {
            employees = company.Employees; 
            companyName = company.Name;
        }
    }
    return $"Company: {companyName}\nEmployees: {employees}";

});
app.MapGet("/about", () =>
{
    var person = new Person();
    app.Configuration.Bind(person);
    string hobbies = "\nHobbies:\n";
    foreach(var hobby in person.Hobbies)
    {
        hobbies += " " + hobby + "\n";
    }
    return $"Name: {person.Name}\tLastname: {person.Lastname}\nAge: {person.Age} {hobbies}";
});
app.Run();

