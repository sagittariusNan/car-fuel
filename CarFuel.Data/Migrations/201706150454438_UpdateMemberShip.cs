namespace CarFuel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberShip : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "PlanCode", "dbo.Plans");
            DropIndex("dbo.Members", new[] { "PlanCode" });
            AlterColumn("dbo.Members", "PlanCode", c => c.String(maxLength: 128));
            CreateIndex("dbo.Members", "PlanCode");
            AddForeignKey("dbo.Members", "PlanCode", "dbo.Plans", "Code");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "PlanCode", "dbo.Plans");
            DropIndex("dbo.Members", new[] { "PlanCode" });
            AlterColumn("dbo.Members", "PlanCode", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Members", "PlanCode");
            AddForeignKey("dbo.Members", "PlanCode", "dbo.Plans", "Code", cascadeDelete: true);
        }
    }
}
