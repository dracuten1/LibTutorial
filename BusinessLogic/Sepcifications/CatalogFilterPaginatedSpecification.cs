using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Sepcifications {
    public class CatalogFilterPaginatedSpecification : BaseSpecification<AssetInLibrary> {
        public CatalogFilterPaginatedSpecification(int skip, int take, int? locationId, int? typeId)
            : base(i => (/*!locationId.HasValue || */i.Location.Id == locationId)
            //&&
            //    (!typeId.HasValue || i.AssetTypeId == typeId)
            ){
            ApplyPaging(skip, take);
        }
    }
}
