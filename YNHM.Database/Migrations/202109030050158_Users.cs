namespace YNHM.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HouseSeekers", "HouseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HouseSeekers", "HouseId", c => c.Int());
        }
    }
}
