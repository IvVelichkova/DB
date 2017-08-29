namespace ExtendetQueryContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ExtendetQueryContext.ExtendetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ExtendetQueryContext.ExtendetContext";
        }

        protected override void Seed(ExtendetQueryContext.ExtendetContext context)
        {
            var client = new Client()
            {
                Name = "Ivan Pertov",
                Address="Sofiq 1000"
                
            };
            var product = new Product()
            {
                Name = "Oil Pump"
            };
            context.Clients.AddOrUpdate(c => c.Name, client);
            context.Products.AddOrUpdate(p => p.Name, product);
            context.SaveChanges();
            var client2 = new Client()
            {
                Name = "Peter Pertov",
                Address="Malinov 3"
            };
            var client3 = new Client()
            {
                Name = "Todor Pertov",
                Address="Stamboliiski 15"
            };
            context.Clients.AddOrUpdate(c => c.Name, client2);
            context.Clients.AddOrUpdate(c => c.Name, client3);
            context.SaveChanges();
            

        }
    }
}
