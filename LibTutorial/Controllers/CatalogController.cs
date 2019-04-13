using System.Linq;
using System.Threading.Tasks;
using Application.Catalogs.Commands.Checkout;
using Application.Catalogs.Queries.GetBookCheckoutDetails;
using Application.Catalogs.Queries.GetBookDetails;
using Application.Catalogs.Queries.GetBooksList;
using Data.Interfaces;
using LibTutorial.Models.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace LibTutorial.Controllers {
    public class CatalogController : BaseController
    {
        public async Task<IActionResult> Index(int pageIndex, int itemsPage, int? brandId, int? typeId)
        {
            #region Old service
            //Ok(await Mediator.Send(new GetCatalogsListQuery()));
            //var assetModels = _assetsService.GetAll();

            //var listingResult = assetModels
            //    .Select(a => new AssetIndexListingModel{
            //        Id = a.Id,
            //        ImageUrl = a.ImageUrl,
            //        AuthorOrDirector = _assetsService.GetAuthorOrDirector(a.Id),
            //        //Dewey = _assetsService.GetDeweyIndex(a.Id),
            //        //CopiesAvailable = _checkoutsService.GetNumberOfCopies(a.Id), // Remove
            //        Title = _assetsService.GetTitle(a.Id),
            //        Type = _assetsService.GetType(a.Id),
            //        //NumberOfCopies = _checkoutsService.GetNumberOfCopies(a.Id)
            //    }).ToList();
            ////var testReposity = await _assetsService.GetItems(0, 10, brandId, typeId);
            //var model = new AssetIndexModel {
            //    Assets = listingResult
            //}; 
            #endregion
            var viewModel = await Mediator.Send(new GetBooksListQuery());
            return View(viewModel);        
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id) {
            #region DetailOldQuery
            //var asset = _assetsService.Get(id);
            //var currentHolds = _checkoutsService.GetCurrentHolds(id).Select(a => new AssetHoldModel {
            //    HoldPlaced = _checkoutsService.GetCurrentHoldPlaced(a.Id),
            //    PatronName = _checkoutsService.GetCurrentHoldPatron(a.Id)
            //});

            //var model = new AssetDetailModel {
            //    AssetId = id,
            //    Title = asset.Title,
            //    Type = _assetsService.GetType(id),
            //    Year = asset.Year,
            //    Cost = asset.Cost,
            //    Status = asset.Status.Name,
            //    ImageUrl = asset.ImageUrl,
            //    AuthorOrDirector = _assetsService.GetAuthorOrDirector(id),
            //    CurrentLocation = _assetsService.GetCurrentLocation(id)?.Name,
            //    Dewey = _assetsService.GetDeweyIndex(id),
            //    CheckoutHistory = _checkoutsService.GetCheckoutHistory(id),
            //    CurrentAssociatedLibraryCard = _assetsService.GetLibraryCardByAssetId(id),
            //    Isbn = _assetsService.GetIsbn(id),
            //    LatestCheckout = _checkoutsService.GetLatestCheckout(id),
            //    CurrentHolds = currentHolds,
            //    PatronName = _checkoutsService.GetCurrentPatron(id)
            //};

            //return View(model); 
            #endregion
            var viewModel = await Mediator.Send(new GetBookDetailQuery() { Id = id });
            return View(viewModel);
            
        }
        public async Task<IActionResult> CheckoutAsync(int catalogId) {
            var viewModel = await Mediator.Send(new GetBookCheckoutPreviewQuery() { Id = catalogId });
            return View("Checkout",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceCheckout([FromBody]CheckoutCommand command) {
            var result = await Mediator.Send(command);
            return View();
        }
        //public IActionResult Hold(int id) {
        //    var asset = _assetsService.Get(id);

        //    var model = new CheckoutModel {
        //        AssetId = id,
        //        ImageUrl = asset.ImageUrl,
        //        Title = asset.Title,
        //        LibraryCardId = "",
        //        HoldCount = _checkoutsService.GetCurrentHolds(id).Count()
        //    };
        //    return View(model);
        //}

        //public IActionResult CheckIn(int id) {
        //    _checkoutsService.CheckInItem(id);
        //    return RedirectToAction("Detail", new { id });
        //}

        //public IActionResult MarkLost(int id) {
        //    _checkoutsService.MarkLost(id);
        //    return RedirectToAction("Detail", new { id });
        //}

        //public IActionResult MarkFound(int id) {
        //    _checkoutsService.MarkFound(id);
        //    return RedirectToAction("Detail", new { id });
        //}

        //[HttpPost]
        //public IActionResult PlaceCheckout(int assetId, int libraryCardId) {
        //    if (!ModelState.IsValid) {
        //        return View();
        //    }
        //    _checkoutsService.CheckoutItem(assetId, libraryCardId);
        //    return RedirectToAction("Detail", new { id = assetId });
        //}

        //[HttpPost]
        //public IActionResult PlaceHold(int assetId, int libraryCardId) {
        //    _checkoutsService.PlaceHold(assetId, libraryCardId);
        //    return RedirectToAction("Detail", new { id = assetId });
        //}
    }
}