namespace CarFuel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberShip : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FillUps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Odometer = c.Int(nullable: false),
                        Liters = c.Double(nullable: false),
                        IsFull = c.Boolean(nullable: false),
                        Car_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .Index(t => t.Car_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PlanCode = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plans", t => t.PlanCode, cascadeDelete: true)
                .Index(t => t.PlanCode);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "PlanCode", "dbo.Plans");
            DropForeignKey("dbo.FillUps", "Car_Id", "dbo.Cars");
            DropIndex("dbo.Members", new[] { "PlanCode" });
            DropIndex("dbo.FillUps", new[] { "Car_Id" });
            DropTable("dbo.Plans");
            DropTable("dbo.Members");
            DropTable("dbo.FillUps");
        }
    }
}
