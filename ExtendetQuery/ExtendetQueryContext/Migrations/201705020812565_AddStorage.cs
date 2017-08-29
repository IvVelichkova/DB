namespace ExtendetQueryContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStorage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Storage_Id", c => c.Int());
            CreateIndex("dbo.Products", "Storage_Id");
            AddForeignKey("dbo.Products", "Storage_Id", "dbo.Storages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Storage_Id", "dbo.Storages");
            DropIndex("dbo.Products", new[] { "Storage_Id" });
            DropColumn("dbo.Products", "Storage_Id");
            DropTable("dbo.Storages");
        }
    }
}
