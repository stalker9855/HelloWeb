using HelloWeb;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Configuration.AddJsonFile("Configurations/Books.json");
List<Book> books = builder.Configuration.GetSection("Books").Get<List<Book>>();
builder.Configuration.AddJsonFile("Configurations/Profiles.json");
List<Profile> profiles = builder.Configuration.GetSection("Profiles").Get<List<Profile>>();
// Token Middlweare || 1g231
app.UseMiddleware<TokenMiddleware>();
app.Map("/", context =>
{
    context.Response.ContentType = "text/html";
    return context.Response.WriteAsync(@"
        <html>
            <body>
                <h1>Hello!</h1>
            </body>
        </html>
    ");
});
app.Map("/Library", context =>
{
    context.Response.ContentType = "text/html";
    return context.Response.WriteAsync(@"
        <html>
            <body>
                <h1>Welcome to Library</h1>
            </body>
        </html>
    ");
});
app.MapGet("Library/Books", async context =>
{
    string content = "";
    foreach(var book in books)
    {
        content += $"{book.Id} - \"{book.Name}\" published by {book.Author} in {book.Year}\n";
    }
    await context.Response.WriteAsync(content);
});
app.Map("/Library/Profile/{id:int:range(0,5)?}", (string? id, HttpContext context) =>
{
    if (int.TryParse(id, out int userId))
    {
        var userProfile = profiles.FirstOrDefault(profile => profile.Id == userId);

        if (userProfile != null)
        {
            return context.Response.WriteAsync($"User Id: {userProfile.Id}, Name: {userProfile.Name}");
        }

    }
    return context.Response.WriteAsync($"User Id: {null}, Name: Guest");
});
app.Run();

