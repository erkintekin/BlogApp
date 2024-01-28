using BlogApp;
using BlogApp.Controllers;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
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

builder.Services.AddScoped<IRepository<Post>, EfRepository<Post>>();
builder.Services.AddScoped<IRepository<Tag>, EfRepository<Tag>>();  // Alan sağlar döngü için (abs. ,concrete)
builder.Services.AddScoped<IRepository<Comment>, EfRepository<Comment>>();
builder.Services.AddScoped<IRepository<User>, EfRepository<User>>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

app.UseStaticFiles();

// Sıralama önemli başta routşng olmalı her zaman.

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

SeedData.TestVerileriniDoldur(app);

// app.MapGet("/", () => "Hello World!");


// url yolalrsak buraya girer
app.MapControllerRoute(
    name: "post_details",
    pattern: "posts/details/{url}",
    defaults: new { controller = "Posts", action = "Details" }
);
app.MapControllerRoute(
    name: "posts_by_tag",
    pattern: "posts/tag/{tag}",
    defaults: new { controller = "Posts", action = "Index" }
);

// app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Posts}/{action=Index}/{id?}"
);


app.Run();
