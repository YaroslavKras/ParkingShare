namespace ParkingShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tryout2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId", "dbo.ParkingSpaces");
            DropForeignKey("dbo.TransactionRecords", "User_UserId", "dbo.Users");
            DropIndex("dbo.TransactionRecords", new[] { "ParkingSpace_ParkingSpaceId" });
            DropIndex("dbo.TransactionRecords", new[] { "User_UserId" });
            AlterColumn("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId", c => c.Int());
            AlterColumn("dbo.TransactionRecords", "User_UserId", c => c.Int());
            CreateIndex("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId");
            CreateIndex("dbo.TransactionRecords", "User_UserId");
            AddForeignKey("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId", "dbo.ParkingSpaces", "ParkingSpaceId");
            AddForeignKey("dbo.TransactionRecords", "User_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionRecords", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId", "dbo.ParkingSpaces");
            DropIndex("dbo.TransactionRecords", new[] { "User_UserId" });
            DropIndex("dbo.TransactionRecords", new[] { "ParkingSpace_ParkingSpaceId" });
            AlterColumn("dbo.TransactionRecords", "User_UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId", c => c.Int(nullable: false));
            CreateIndex("dbo.TransactionRecords", "User_UserId");
            CreateIndex("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId");
            AddForeignKey("dbo.TransactionRecords", "User_UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId", "dbo.ParkingSpaces", "ParkingSpaceId", cascadeDelete: true);
        }
    }
}
