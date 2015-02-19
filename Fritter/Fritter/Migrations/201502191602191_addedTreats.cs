namespace Fritter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTreats : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Treats",
                c => new
                    {
                        TreatId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        Creator_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TreatId)
                .ForeignKey("dbo.AspNetUsers", t => t.Creator_Id)
                .Index(t => t.Creator_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Treats", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Treats", new[] { "Creator_Id" });
            DropTable("dbo.Treats");
        }
    }
}
