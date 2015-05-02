namespace Client.Migrations
{
    using Client.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Client.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Client.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            var passwordHash = new PasswordHasher();

            var users =  new List<ApplicationUser>{
                new ApplicationUser()
                {
                    Email = "user1@mail.com",
                    PasswordHash = passwordHash.HashPassword("Password1"),
                    UserName = "jamie coleman"
                },
             new ApplicationUser()
             {
                 Email = "user2@mail.com",
                 PasswordHash = passwordHash.HashPassword("Password2"),
                 UserName = "arnold schwarzenegger"
             },
             new ApplicationUser()
             {
                 Email = "user3@mail.com",
                 PasswordHash = passwordHash.HashPassword("Password3"),
                 UserName = "jim carrey"
             }
            };

            context.Users.AddOrUpdate(users.ToArray());


            context.Comments.AddOrUpdate(
                new Comment() 
                {
                    Text = "This site is awesome!",
                    UserId = users[0].Id
                },
                new Comment() 
                {
                    Text = "I like jogging",
                    UserId = users[1].Id
                },
                new Comment() 
                {
                    Text = "We have a bug..",
                    UserId = users[1].Id
                },
                new Comment() 
                {
                    Text = "I believe a can fly...!!!",
                    UserId = users[2].Id
                },
                new Comment() 
                {
                    Text = "I believe i can touch the sky!",
                    UserId = users[2].Id
                });
        }
    }
}
