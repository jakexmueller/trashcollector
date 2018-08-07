namespace trashcollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerModelUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "pickupComplete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "pickupComplete");
        }
    }
}
