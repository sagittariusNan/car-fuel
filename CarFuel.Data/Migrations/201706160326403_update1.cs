namespace CarFuel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FillUps", "NextFillUp_Id", c => c.Int());
            CreateIndex("dbo.FillUps", "NextFillUp_Id");
            AddForeignKey("dbo.FillUps", "NextFillUp_Id", "dbo.FillUps", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FillUps", "NextFillUp_Id", "dbo.FillUps");
            DropIndex("dbo.FillUps", new[] { "NextFillUp_Id" });
            DropColumn("dbo.FillUps", "NextFillUp_Id");
        }
    }
}
