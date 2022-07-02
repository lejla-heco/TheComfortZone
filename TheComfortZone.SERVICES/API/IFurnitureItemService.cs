using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Charts;
using TheComfortZone.DTO.FurnitureItem;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.SERVICES.API
{
    public interface IFurnitureItemService : ICRUDService<FurnitureItemResponse, FurnitureItemSearchRequest, FurnitureItemUpsertRequest, FurnitureItemUpsertRequest>
    {
        public Task<List<FurnitureItemResponse>> getFurnitureItemsUserData(int id, FurnitureItemSearchRequest search = null);
        public Task<string> likeFurnitureItem(int userId, int furnitureItemId);
    }
}
