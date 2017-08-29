namespace ExtendetQueryContext
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Migrations;


    public class ExtendetContext : DbContext
    {
       
        public ExtendetContext()
            : base("name=ExtendetContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ExtendetContext, Configuration>());
        }

        
         public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Storage> Storage { get; set; }
    }


}


   
