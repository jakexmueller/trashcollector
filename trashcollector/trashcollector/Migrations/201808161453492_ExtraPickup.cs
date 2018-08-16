namespace trashcollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtraPickup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ExtraPickup", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ExtraPickup");
        }
    }
}
