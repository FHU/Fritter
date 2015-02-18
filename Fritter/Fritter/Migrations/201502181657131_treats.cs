namespace Fritter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class treats : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Treats",
                c => new
                    {
                        TreatId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        UserName = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TreatId);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Bio", c => c.String());
            AddColumn("dbo.AspNetUsers", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ImageName");
            DropColumn("dbo.AspNetUsers", "Bio");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Treats");
        }
    }
}
