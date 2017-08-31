namespace ATS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortName = c.String(nullable: false),
                        Code = c.String(),
                        OrganizationId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortName = c.String(nullable: false),
                        Code = c.String(),
                        BranchId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortName = c.String(nullable: false),
                        Location = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortName = c.String(nullable: false),
                        Description = c.String(),
                        GenCategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.GenCategories", t => t.GenCategoryId, cascadeDelete: true)
                .Index(t => t.GenCategoryId);
            
            CreateTable(
                "dbo.GenCategories",
                c => new
                    {
                        GenCategoryId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortName = c.String(nullable: false, maxLength: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GenCategoryId);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SubCategoryId = c.Long(nullable: false),
                        ManufacturerId = c.Long(nullable: false),
                        Category_CategoryId = c.Long(),
                    })
                .PrimaryKey(t => t.ModelId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.ManufacturerId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.PurchasedAssets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VendorName = c.String(),
                        VendorAddress = c.String(),
                        PurchasedDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SerialNo = c.Int(nullable: false),
                        WarrantyPeriod = c.Int(nullable: false),
                        ModelId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.RegisteredAssets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RegisteredId = c.String(nullable: false),
                        LocationId = c.Long(nullable: false),
                        PurchasedAssetId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.PurchasedAssets", t => t.PurchasedAssetId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.PurchasedAssetId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegisteredAssets", "PurchasedAssetId", "dbo.PurchasedAssets");
            DropForeignKey("dbo.RegisteredAssets", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.PurchasedAssets", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Models", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "GenCategoryId", "dbo.GenCategories");
            DropForeignKey("dbo.Branches", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Locations", "BranchId", "dbo.Branches");
            DropIndex("dbo.RegisteredAssets", new[] { "PurchasedAssetId" });
            DropIndex("dbo.RegisteredAssets", new[] { "LocationId" });
            DropIndex("dbo.PurchasedAssets", new[] { "ModelId" });
            DropIndex("dbo.Models", new[] { "Category_CategoryId" });
            DropIndex("dbo.Models", new[] { "ManufacturerId" });
            DropIndex("dbo.Categories", new[] { "GenCategoryId" });
            DropIndex("dbo.Locations", new[] { "BranchId" });
            DropIndex("dbo.Branches", new[] { "OrganizationId" });
            DropTable("dbo.SubCategories");
            DropTable("dbo.RegisteredAssets");
            DropTable("dbo.PurchasedAssets");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Models");
            DropTable("dbo.GenCategories");
            DropTable("dbo.Categories");
            DropTable("dbo.Organizations");
            DropTable("dbo.Locations");
            DropTable("dbo.Branches");
        }
    }
}
