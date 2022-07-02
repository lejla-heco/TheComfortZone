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
        public Task<List<FurnitureItemResponse>> GetFurnitureItemsUserData(int id, FurnitureItemSearchRequest search = null);
        public Task<string> LikeFurnitureItem(int userId, int furnitureItemId);
        public Task<List<FurnitureItemResponse>> GetFavourites(int userId, FurnitureItemSearchRequest search = null);
        public Task<string> DeleteFavourite(int userId, int furnitureItemId);
    }
}
