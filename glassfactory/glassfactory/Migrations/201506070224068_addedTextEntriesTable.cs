namespace glassfactory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTextEntriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TextEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryName = c.String(),
                        AuthorName = c.String(),
                        EntryBody = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TextEntries");
        }
    }
}
