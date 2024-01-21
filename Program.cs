using BlogApp;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>
{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
});
// Desing Pattern- Repository Design Pattern
builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();  // Alan sağlar döngü için (abs. ,concrete)
var app = builder.Build();

app.UseStaticFiles();

SeedData.TestVerileriniDoldur(app);

// app.MapGet("/", () => "Hello World!");
app.MapDefaultControllerRoute();
app.Run();
