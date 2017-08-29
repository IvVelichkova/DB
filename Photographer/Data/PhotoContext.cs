namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Migrations;

    public class PhotoContext : DbContext
    {

        public PhotoContext()
            : base("name=PhotoContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotoContext, Configuration>());
            Database.SetInitializer(new DropCreateDatabaseAlways<PhotoContext>());
        }



        public virtual DbSet<Photographer> Photographers { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
    }


}