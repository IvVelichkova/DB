namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Data.PhotoContext";
        }

        protected override void Seed(PhotoContext context)
        {
            var p1 = new Photographer()
            {
                Username = "Ivan",
                Password = "123456",
                Email = "ivan@abv.bg",
                RegisterDate = DateTime.Now,
                BirthDay = DateTime.Now
            };
            var p2 = new Photographer()
            {
                Username = "Pesho",
                Password = "123456",
                Email = "Pesho@abv.bg",
                RegisterDate = DateTime.Now,
                BirthDay = DateTime.Now
            };
            var p3 = new Photographer()
            {
                Username = "Tosho",
                Password = "123456",
                Email = "Tosho@abv.bg",
                RegisterDate = DateTime.Now,
                BirthDay = DateTime.Now
            };
            context.Photographers.AddRange(new[] { p1, p2, p3 });
            context.SaveChanges();


            var album1 = new Album()
            {
                Name = "Vitosha",
                BackgroundColor = "black",
                IsPublic = true,
                PhotographerId = p1.Id,

            };
            context.Albums.AddOrUpdate(n => n.Name, album1);
            context.SaveChanges();
            var pic1 = new Picture()
            {
               Title="Pic1Za Vitosha",
               PathFile="/../.../",
               Caption="123"
            };
            context.Pictures.AddOrUpdate(n => n.Title, pic1);
            album1.Pictures.Add(pic1);
            p1.Albums.Add(album1);
            context.SaveChanges();
        }
    }
}
