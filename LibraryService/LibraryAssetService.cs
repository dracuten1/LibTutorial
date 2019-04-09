using BusinessLogic.Sepcifications;
using Dao.Dao;
using Data;
using Data.Exceptions;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryService {
    public class LibraryAssetService : ILibraryAsset {
        private LibraryContext _context;
        private LibraryAssetDao _assetDao;
        public LibraryAssetService(LibraryContext context) {
            _context = context;
            _assetDao = new LibraryAssetDao(context);
        }
        public void Add(LibraryAsset newAsset) {
            if (_context.LibraryAssets.Count(asset => asset.Title.Equals(newAsset.Title))>0) {
                throw new AssetExistedException("Asset title existed", newAsset.Title);
            }
            _context.LibraryAssets.Add(newAsset);
            _context.SaveChanges();
        }

        public LibraryAsset Get(int id) {
            return _context.LibraryAssets
                .Include(a => a.Status)
                .Include(a => a.Location)
                .FirstOrDefault(a => a.Id == id);

        }

        public IEnumerable<LibraryAsset> GetAll() {
            return _context.LibraryAssets
                .Include(a => a.Status)
                .Include(a => a.Location);
        }

        public string GetAuthorOrDirector(int id) {
            var isBook = _context.LibraryAssets
                .OfType<Book>().Any(a => a.Id == id);

            return isBook
                ? GetAuthor(id)
                : GetDirector(id);
        }

        private string GetDirector(int id) {
            var video = (Video)Get(id);
            return video.Director;
        }

        private string GetAuthor(int id) {
            var book = (Book)Get(id);
            return book.Author;
        }

        public LibraryBranch GetCurrentLocation(int id) {
            return _context.LibraryAssets.First(a => a.Id == id).Location;
        }

        public string GetDeweyIndex(int id) {
            if (GetType(id) != "Book") return "N/A";
            var book = (Book)Get(id);
            return book.DeweyIndex;
        }

        public string GetIsbn(int id) {
            if (GetType(id) != "Book") return "N/A";
            var book = (Book)Get(id);
            return book.ISBN;
        }

        public LibraryCard GetLibraryCardByAssetId(int id) {
            return _context.LibraryCards
                .FirstOrDefault(c => c.Checkouts
                    .Select(a => a.LibraryAsset)
                    .Select(v => v.Id).Contains(id));
        }

        public string GetTitle(int id) {
            return _context.LibraryAssets.First(a => a.Id == id).Title;
        }

        public string GetType(int id) {
            // Hack
            var book = _context.LibraryAssets
                .OfType<Book>().SingleOrDefault(a => a.Id == id);
            return book != null ? "Book" : "Video";
        }

        public async Task<IEnumerable<LibraryAsset>> GetItems(int pageIndex, int itemsPage, int? locationId, int? typeId) {
            var filterSpecification = new CatalogFilterSpecification(locationId, typeId);
            //TODO: paging
            //TIME: 25/3/2019.
            //By: MinhTuyen
            var filterPaginatedSpecification = 
                new CatalogFilterPaginatedSpecification(itemsPage * pageIndex, itemsPage, locationId, typeId);
            // the implementation below using ForEach and Count. We need a List.
            var itemsOnPage = await _assetDao.ListAsync(filterPaginatedSpecification);
            throw new NotImplementedException();
        }
    }
}
