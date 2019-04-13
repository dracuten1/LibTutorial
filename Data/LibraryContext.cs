﻿using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data {
    public class LibraryContext : DbContext {
        public LibraryContext(DbContextOptions options):base(options) {

        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Asset> AssetDetails { get; set; }
        public virtual DbSet<CheckoutHistory> CheckoutHistories { get; set; }
        public virtual DbSet<LibraryBranch> LibraryBranches { get; set; }
        public virtual DbSet<BranchHours> BranchHours { get; set; }
        public virtual DbSet<LibraryCard> LibraryCards { get; set; }
        public virtual DbSet<Patron> Patrons { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<LibraryAsset> LibraryAssets { get; set; }
        public virtual DbSet<AssetType> AssetTypes { get; set; }
        public virtual DbSet<Hold> Holds { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
    }
}
