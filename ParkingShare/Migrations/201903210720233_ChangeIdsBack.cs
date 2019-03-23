namespace ParkingShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdsBack : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ParkingSpaces", name: "User_UserId", newName: "Owner_UserId");
            RenameIndex(table: "dbo.ParkingSpaces", name: "IX_User_UserId", newName: "IX_Owner_UserId");
            AddColumn("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId", c => c.Int());
            AddColumn("dbo.TransactionRecords", "User_UserId", c => c.Int());
            CreateIndex("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId");
            CreateIndex("dbo.TransactionRecords", "User_UserId");
            AddForeignKey("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId", "dbo.ParkingSpaces", "ParkingSpaceId");
            AddForeignKey("dbo.TransactionRecords", "User_UserId", "dbo.Users", "UserId");
            DropColumn("dbo.TransactionRecords", "UserId");
            DropColumn("dbo.TransactionRecords", "ParkingSpaceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransactionRecords", "ParkingSpaceId", c => c.Int(nullable: false));
            AddColumn("dbo.TransactionRecords", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TransactionRecords", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId", "dbo.ParkingSpaces");
            DropIndex("dbo.TransactionRecords", new[] { "User_UserId" });
            DropIndex("dbo.TransactionRecords", new[] { "ParkingSpace_ParkingSpaceId" });
            DropColumn("dbo.TransactionRecords", "User_UserId");
            DropColumn("dbo.TransactionRecords", "ParkingSpace_ParkingSpaceId");
            RenameIndex(table: "dbo.ParkingSpaces", name: "IX_Owner_UserId", newName: "IX_User_UserId");
            RenameColumn(table: "dbo.ParkingSpaces", name: "Owner_UserId", newName: "User_UserId");
        }
    }
}
