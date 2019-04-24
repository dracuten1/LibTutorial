using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data {
    public class LibraryContext : DbContext {
        public LibraryContext(DbContextOptions options):base(options) {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<CheckoutHistory> CheckoutHistories { get; set; }
        public virtual DbSet<LibraryBranch> LibraryBranches { get; set; }
        public virtual DbSet<BranchHours> BranchHours { get; set; }
        public virtual DbSet<LibraryCard> LibraryCards { get; set; }
        public virtual DbSet<Patron> Patrons { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<AssetInLibrary> AssetInLibrary { get; set; }
        public virtual DbSet<AssetCategory> AssetCategories { get; set; }
        public virtual DbSet<Hold> Holds { get; set; }
        public virtual DbSet<CategoryAttribute> AttributeTypes { get; set; }
        public virtual DbSet<AttributeValue> AttributeValues { get; set; }
    }

}
