namespace ParkingShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionRecords",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        ParkingSpace_ParkingSpaceId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.ParkingSpaces", t => t.ParkingSpace_ParkingSpaceId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.ParkingSpace_ParkingSpaceId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.ParkingSpaces",
                c => new
                    {
                        ParkingSpaceId = c.Int(nullable: false, identity: true),
                        IsAvailable = c.Boolean(nullable: false),
                        Number = c.String(),
                        OwnerId = c.Int(),
                        Owner_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ParkingSpaceId)
                .ForeignKey("dbo.Users", t => t.Owner_UserId)
                .Index(t => t.Owner_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsHost = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionRecords", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId", "dbo.ParkingSpaces");
            DropForeignKey("dbo.ParkingSpaces", "Owner_UserId", "dbo.Users");
            DropIndex("dbo.ParkingSpaces", new[] { "Owner_UserId" });
            DropIndex("dbo.TransactionRecords", new[] { "User_UserId" });
            DropIndex("dbo.TransactionRecords", new[] { "ParkingSpace_ParkingSpaceId" });
            DropTable("dbo.Users");
            DropTable("dbo.ParkingSpaces");
            DropTable("dbo.TransactionRecords");
        }
    }
}
