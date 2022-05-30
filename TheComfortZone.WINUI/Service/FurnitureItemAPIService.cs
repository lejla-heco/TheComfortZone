using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.FurnitureItem;

namespace TheComfortZone.WINUI.Service
{
    public class FurnitureItemAPIService : BaseAPIService<FurnitureItemResponse, FurnitureItemSearchRequest, FurnitureItemUpsertRequest, FurnitureItemUpsertRequest>
    {
        private const string API_ROUTE = "FurnitureItem";
        public FurnitureItemAPIService() : base(API_ROUTE)
        {
        }
    }
}
