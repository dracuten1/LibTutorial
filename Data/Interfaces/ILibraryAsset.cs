using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces {
    public interface ILibraryAsset {
        IEnumerable<AssetInLibrary> GetAll();
        AssetInLibrary Get(int id);
        Task<IEnumerable<AssetInLibrary>> GetItems(int pageIndex, int itemsPage, int? brandId, int? typeId);

        void Add(AssetInLibrary newAsset);
        string GetAuthorOrDirector(int id);
        string GetDeweyIndex(int id);
        string GetType(int id);
        string GetTitle(int id);
        string GetIsbn(int id);

        LibraryBranch GetCurrentLocation(int id);
        LibraryCard GetLibraryCardByAssetId(int id);
    }
}
