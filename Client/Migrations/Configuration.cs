namespace Client.Migrations
{
    using Client.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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

            var store = new UserStore<ApplicationUser>(context);
            var manager = new ApplicationUserManager(store);

            var user = new ApplicationUser()
            {
                Email = "user1@mail.com",
                UserName = "jamie coleman"
            };

            manager.CreateAsync(user, "Password1");


            user.Email = "user1@mail.com";
            user.UserName = "jamie coleman";
            manager.CreateAsync(user, "Password1");


            user.Email = "user3@mail.com";
            user.UserName = "jim carrey";
            manager.CreateAsync(user, "Password1");


            user.Email = "user2@mail.com";
            user.UserName = "arnold schwarzenegger";
            manager.CreateAsync(user, "Password1");

            var users = context.Users.ToList();

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
