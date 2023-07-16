
using Crypto.Web.MVC;

var builder = WebApplication.CreateBuilder(args);

var root = Directory.GetCurrentDirectory();
var parentDirectory = Directory.GetParent(root)?.FullName;
var dotenv = Path.Combine(parentDirectory, ".env");
DotEnv.Load(dotenv);

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();

var configuration = new  ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

