namespace CarFuel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCar : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Cars");
            AlterColumn("dbo.Cars", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql:"newid()"));
            AlterColumn("dbo.Cars", "Name", c => c.String(maxLength: 20));
            AlterColumn("dbo.Cars", "PlateNo", c => c.String(maxLength: 20));
            AlterColumn("dbo.Cars", "Make", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Cars", "Model", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Cars", "EngineSizeCC", c => c.Int());
            AlterColumn("dbo.Cars", "OwnerId", c => c.String(maxLength: 36));
            AddPrimaryKey("dbo.Cars", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Cars");
            AlterColumn("dbo.Cars", "OwnerId", c => c.String());
            AlterColumn("dbo.Cars", "EngineSizeCC", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "Model", c => c.String());
            AlterColumn("dbo.Cars", "Make", c => c.String());
            AlterColumn("dbo.Cars", "PlateNo", c => c.String());
            AlterColumn("dbo.Cars", "Name", c => c.String());
            AlterColumn("dbo.Cars", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Cars", "Id");
        }
    }
}
