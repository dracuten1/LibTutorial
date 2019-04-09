using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces {
    public interface ILibraryAsset {
        IEnumerable<LibraryAsset> GetAll();
        LibraryAsset Get(int id);
        Task<IEnumerable<LibraryAsset>> GetItems(int pageIndex, int itemsPage, int? brandId, int? typeId);

        void Add(LibraryAsset newAsset);
        string GetAuthorOrDirector(int id);
        string GetDeweyIndex(int id);
        string GetType(int id);
        string GetTitle(int id);
        string GetIsbn(int id);

        LibraryBranch GetCurrentLocation(int id);
        LibraryCard GetLibraryCardByAssetId(int id);
    }
}
