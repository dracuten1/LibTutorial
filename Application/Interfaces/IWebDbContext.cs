using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces {
    public interface IWebDbContext {
         DbSet<Product> Products { get; set; }
         DbSet<CheckoutHistory> CheckoutHistories { get; set; }
         DbSet<LibraryBranch> LibraryBranches { get; set; }
         DbSet<BranchHours> BranchHours { get; set; }
         DbSet<LibraryCard> LibraryCards { get; set; }
         DbSet<Patron> Patrons { get; set; }
         DbSet<Status> Statuses { get; set; }
         DbSet<AssetInLibrary> AssetInLibrary { get; set; }
         DbSet<AssetCategory> AssetCategories { get; set; }
         DbSet<Hold> Holds { get; set; }
         DbSet<CategoryAttribute> AttributeTypes { get; set; }
         DbSet<AttributeValue> AttributeValues { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
