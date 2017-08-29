namespace StationsExam.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Age = c.Int(nullable: false),
                        CardType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SeatingClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Abbreviation = c.String(nullable: false, maxLength: 2),
                        Train_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trains", t => t.Train_Id)
                .Index(t => t.Train_Id);
            
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainNumber = c.String(nullable: false, maxLength: 10),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainSeats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrainId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SeatingClass_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SeatingClasses", t => t.SeatingClass_Id)
                .ForeignKey("dbo.Trains", t => t.TrainId, cascadeDelete: false)
                .Index(t => t.TrainId)
                .Index(t => t.SeatingClass_Id);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginStationId = c.Int(nullable: false),
                        DestinationStationId = c.Int(nullable: false),
                        DepartureTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        DifferenceTime = c.Time(nullable: false, precision: 7),
                        Train_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stations", t => t.DestinationStationId, cascadeDelete: false)
                .ForeignKey("dbo.Stations", t => t.OriginStationId, cascadeDelete: false)
                .ForeignKey("dbo.Trains", t => t.Train_Id)
                .Index(t => t.OriginStationId)
                .Index(t => t.DestinationStationId)
                .Index(t => t.Train_Id);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Town = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TripId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SeatingPlace = c.String(nullable: false, maxLength: 8),
                        PersonalCard_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerCards", t => t.PersonalCard_Id)
                .ForeignKey("dbo.Trips", t => t.TripId, cascadeDelete: false)
                .Index(t => t.TripId)
                .Index(t => t.PersonalCard_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TripId", "dbo.Trips");
            DropForeignKey("dbo.Tickets", "PersonalCard_Id", "dbo.CustomerCards");
            DropForeignKey("dbo.Trips", "Train_Id", "dbo.Trains");
            DropForeignKey("dbo.Trips", "OriginStationId", "dbo.Stations");
            DropForeignKey("dbo.Trips", "DestinationStationId", "dbo.Stations");
            DropForeignKey("dbo.TrainSeats", "TrainId", "dbo.Trains");
            DropForeignKey("dbo.TrainSeats", "SeatingClass_Id", "dbo.SeatingClasses");
            DropForeignKey("dbo.SeatingClasses", "Train_Id", "dbo.Trains");
            DropIndex("dbo.Tickets", new[] { "PersonalCard_Id" });
            DropIndex("dbo.Tickets", new[] { "TripId" });
            DropIndex("dbo.Trips", new[] { "Train_Id" });
            DropIndex("dbo.Trips", new[] { "DestinationStationId" });
            DropIndex("dbo.Trips", new[] { "OriginStationId" });
            DropIndex("dbo.TrainSeats", new[] { "SeatingClass_Id" });
            DropIndex("dbo.TrainSeats", new[] { "TrainId" });
            DropIndex("dbo.SeatingClasses", new[] { "Train_Id" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Stations");
            DropTable("dbo.Trips");
            DropTable("dbo.TrainSeats");
            DropTable("dbo.Trains");
            DropTable("dbo.SeatingClasses");
            DropTable("dbo.CustomerCards");
        }
    }
}
