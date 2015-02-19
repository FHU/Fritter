namespace Fritter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appUserIDString : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Treats", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Treats", "ApplicationUserId");
            RenameColumn(table: "dbo.Treats", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Treats", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Treats", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Treats", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Treats", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Treats", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Treats", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Treats", "ApplicationUser_Id");
        }
    }
}
