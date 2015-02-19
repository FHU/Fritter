namespace Fritter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Treats", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Treats", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Treats", "ApplicationUser_Id");
            AddForeignKey("dbo.Treats", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Treats", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Treats", "UserName", c => c.String());
            DropForeignKey("dbo.Treats", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Treats", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Treats", "ApplicationUser_Id");
            DropColumn("dbo.Treats", "ApplicationUserId");
        }
    }
}
