namespace ParkingShare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdsMore : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ParkingSpaces", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkingSpaces", "OwnerId", c => c.Int());
        }
    }
}
