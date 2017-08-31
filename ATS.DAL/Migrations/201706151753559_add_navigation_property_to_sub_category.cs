namespace ATS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_navigation_property_to_sub_category : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.SubCategories", "CategoryId");
            AddForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
        }
    }
}
