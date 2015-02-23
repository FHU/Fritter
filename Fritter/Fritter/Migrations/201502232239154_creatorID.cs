namespace Fritter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatorID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Treats", name: "Creator_Id", newName: "CreatorID");
            RenameIndex(table: "dbo.Treats", name: "IX_Creator_Id", newName: "IX_CreatorID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Treats", name: "IX_CreatorID", newName: "IX_Creator_Id");
            RenameColumn(table: "dbo.Treats", name: "CreatorID", newName: "Creator_Id");
        }
    }
}
