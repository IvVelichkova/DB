namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class ProductShopContext : DbContext
    {

        public ProductShopContext()
            : base("name=ProductShopContext")
        {
        }



        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.BoughtProducts)
                .WithOptional(p => p.Buyer);

            modelBuilder.Entity<User>().HasMany(a => a.SoldProducts).WithRequired(p => p.Seller);

            modelBuilder.Entity<User>().HasMany(a => a.Friends).WithMany();
            //modelBuilder.Entity<User>()
            //    .HasMany(l => l.Friends)
            //    .WithMany()
            //    .Map(mc =>
            //    {
            //        mc.MapLeftKey("UserId");
            //        mc.MapRightKey("FriendId");
            //        mc.ToTable("UserFriends");

            //    });

            //modelBuilder.Entity<UserFriend>()
            //    .HasRequired(a => a.User)
            //    .WithMany(k => k.Friends)
            //    .HasForeignKey(u => u.UserID)
            //    .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }


}