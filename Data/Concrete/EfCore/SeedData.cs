using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp;

public class SeedData
{
    public static void TestVerileriniDoldur(IApplicationBuilder app)
    {
        var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

        if (context != null)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Tags.Any())
            {
                // Tag'te data yoksa
                context.Tags.AddRange(
                    new Tag { Text = "web-programlama" },
                    new Tag { Text = "back-end" },
                    new Tag { Text = "front-end" },
                    new Tag { Text = "fullstack" },
                    new Tag { Text = "react" }

                );
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { UserName = "bciga" },
                    new User { UserName = "erkin" }
                );
                context.SaveChanges();
            }
            if (!context.Posts.Any())
            {
                // Tag'te data yoksa
                context.Posts.AddRange(
                    new Post
                    {
                        Title = "ASP.NET Core",
                        Content = "ASP.NET Core Dersleri",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-10),
                        Tags = context.Tags.Take(3).ToList(),
                        Image = "1.jpg",
                        UserId = 1
                    },
                    new Post
                    {
                        Title = "React.js",
                        Content = "React.js Dersleri",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-20),
                        Tags = context.Tags.Take(3).ToList(),
                        Image = "2.jpg",
                        UserId = 1
                    },
                    new Post
                    {
                        Title = "MongoDB",
                        Content = "MongoDB Dersleri",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-5),
                        Tags = context.Tags.Take(3).ToList(),
                        Image = "3.jpg",
                        UserId = 2
                    }

                );
                context.SaveChanges();
            }

        }
    }


}
