using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Sepcifications {
    public class CatalogFilterSpecification : BaseSpecification<AssetInLibrary> {
        public CatalogFilterSpecification(int? locationId, int? typeId)
            : base(i => (!locationId.HasValue || i.Location.Id == locationId) &&
                (!typeId.HasValue /*|| i.AssetTypeId == typeId*/)) {
        }
    }
}
