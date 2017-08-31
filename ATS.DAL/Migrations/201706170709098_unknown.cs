namespace ATS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unknown : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Categories", "ShortName", c => c.String());
            AlterColumn("dbo.GenCategories", "Name", c => c.String());
            AlterColumn("dbo.GenCategories", "ShortName", c => c.String(maxLength: 2));
            AlterColumn("dbo.Models", "Name", c => c.String());
            AlterColumn("dbo.Manufacturers", "Name", c => c.String());
            AlterColumn("dbo.SubCategories", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubCategories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Manufacturers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Models", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.GenCategories", "ShortName", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.GenCategories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "ShortName", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
        }
    }
}
