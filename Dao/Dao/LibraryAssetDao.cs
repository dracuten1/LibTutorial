using Data;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Dao {
    public class LibraryAssetDao : EfRepository<LibraryAsset> {
        public LibraryAssetDao(LibraryContext dbContext) : base(dbContext) {
        }
    }
}
