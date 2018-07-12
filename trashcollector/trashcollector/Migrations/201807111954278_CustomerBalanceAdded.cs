namespace trashcollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerBalanceAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Balance", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Balance");
        }
    }
}
