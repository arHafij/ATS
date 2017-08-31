using System.Data.Entity;
using ATS.Models;

namespace ATS.DAL.Database
{
    public class AssetTrackingSystemContext:DbContext
    {
        public AssetTrackingSystemContext() : base("ATSContext")
        {

        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<GenCategory> GenCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<PurchasedAsset> PurchasedAssets { get; set; }
        public DbSet<RegisteredAsset> RegisterAssets { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }


    }
}