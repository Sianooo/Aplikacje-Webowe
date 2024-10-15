var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();
app.UseStaticFiles();
app.MapRazorPages();//pages i strona index.cshtml
// app.MapGet("/", () => "Hello World!");

app.Run();
