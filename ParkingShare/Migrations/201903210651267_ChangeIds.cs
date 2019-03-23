namespace ParkingShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId", "dbo.ParkingSpaces");
            DropForeignKey("dbo.TransactionRecords", "User_UserId", "dbo.Users");
            DropIndex("dbo.TransactionRecords", new[] { "ParkingSpace_ParkingSpaceId" });
            DropIndex("dbo.TransactionRecords", new[] { "User_UserId" });
            RenameColumn(table: "dbo.ParkingSpaces", name: "Owner_UserId", newName: "User_UserId");
            RenameIndex(table: "dbo.ParkingSpaces", name: "IX_Owner_UserId", newName: "IX_User_UserId");
            AddColumn("dbo.TransactionRecords", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.TransactionRecords", "ParkingSpaceId", c => c.Int(nullable: false));
            DropColumn("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId");
            DropColumn("dbo.TransactionRecords", "User_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransactionRecords", "User_UserId", c => c.Int());
            AddColumn("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId", c => c.Int());
            DropColumn("dbo.TransactionRecords", "ParkingSpaceId");
            DropColumn("dbo.TransactionRecords", "UserId");
            RenameIndex(table: "dbo.ParkingSpaces", name: "IX_User_UserId", newName: "IX_Owner_UserId");
            RenameColumn(table: "dbo.ParkingSpaces", name: "User_UserId", newName: "Owner_UserId");
            CreateIndex("dbo.TransactionRecords", "User_UserId");
            CreateIndex("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId");
            AddForeignKey("dbo.TransactionRecords", "User_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId", "dbo.ParkingSpaces", "ParkingSpaceId");
        }
    }
}
