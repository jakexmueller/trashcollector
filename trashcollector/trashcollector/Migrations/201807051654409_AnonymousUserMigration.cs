namespace trashcollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnonymousUserMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnonymousUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AnonymousUsers");
        }
    }
}
