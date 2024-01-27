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
                    new Tag { Text = "web-programlama", Url = "web-programlama", Colors = TagColors.info },
                    new Tag { Text = "back-end", Url = "back-end", Colors = TagColors.primary },
                    new Tag { Text = "front-end", Url = "front-end", Colors = TagColors.dark },
                    new Tag { Text = "fullstack", Url = "fullstack", Colors = TagColors.success },
                    new Tag { Text = "react", Url = "react", Colors = TagColors.info }

                );
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { UserName = "bciga", Image = "profile-img2.jpg", Name = "Barbaros Ciga", Email = "bciga@bc.com", Password = "123456" },
                    new User { UserName = "erkin", Image = "doge-profile.jpg", Name = "Erkin Tekin", Email = "et@et.com", Password = "098766" }
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
                        UserId = 1,
                        Url = "asp-net-core",
                        Comments = new List<Comment>{
                            new Comment {Text = "Ben bu kursta çok faydalandım, teşekkürler!",PublishedOn = DateTime.Now, UserId=2}
                        }
                    },
                    new Post
                    {
                        Title = "React.js",
                        Content = "React.js Dersleri",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-20),
                        Tags = context.Tags.Take(3).ToList(),
                        Image = "2.jpg",
                        UserId = 1,
                        Url = "react-js",
                        Comments = new List<Comment>{
                            new Comment {Text = "Elinize sağlık!",PublishedOn = DateTime.Now, UserId=2}
                        }
                    },
                    new Post
                    {
                        Title = "MongoDB",
                        Content = "MongoDB Dersleri",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-5),
                        Tags = context.Tags.Take(3).ToList(),
                        Image = "3.jpg",
                        UserId = 2,
                        Url = "mongo-db",
                        Comments = new List<Comment>{
                            new Comment {Text = "Çok iyi!",PublishedOn =new DateTime(), UserId=1}
                        }
                    }, new Post
                    {
                        Title = "React Native",
                        Content = "React Native Dersleri",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-1),
                        Tags = context.Tags.Take(5).ToList(),
                        Image = "3.jpg",
                        UserId = 1,
                        Url = "react-native",
                        Comments = new List<Comment>{
                            new Comment {Text = "Çok zorlandım :(",PublishedOn =new DateTime(), UserId=2}
                        }
                    },
                    new Post
                    {
                        Title = "Python",
                        Content = "Python Dersleri",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-5),
                        Tags = context.Tags.Take(1).ToList(),
                        Image = "2.jpg",
                        UserId = 1,
                        Url = "python"
                    },
                    new Post
                    {
                        Title = "MS SQL",
                        Content = "MS SQL Dersleri",
                        IsActive = true,
                        PublishedOn = DateTime.Now.AddDays(-4),
                        Tags = context.Tags.Take(2).ToList(),
                        Image = "1.jpg",
                        UserId = 1,
                        Url = "ms-sql"
                    }

                );
                context.SaveChanges();
            }

        }
    }


}
