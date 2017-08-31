namespace ATS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_navigation_property_to_model : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Models", "SubCategoryId");
            AddForeignKey("dbo.Models", "SubCategoryId", "dbo.SubCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "SubCategoryId", "dbo.SubCategories");
            DropIndex("dbo.Models", new[] { "SubCategoryId" });
        }
    }
}
