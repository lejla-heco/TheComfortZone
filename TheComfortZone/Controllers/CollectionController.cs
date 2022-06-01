using Microsoft.AspNetCore.Mvc;
using TheComfortZone.DTO.Collection;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    public class CollectionController : BaseCRUDController<CollectionResponse, BaseSearchObject, CollectionUpsertRequest, CollectionUpsertRequest>
    {
        private readonly ICollectionService collectionService;

        public CollectionController(ICollectionService service) : base(service)
        {
            collectionService = service;
        }

        [HttpGet("collections-by-designer-id/{id}")]
        public async Task<List<DTO.Collection.CollectionResponse>> GetCollectionsByDesignerId(int id)
        {
            return await collectionService.GetCollectionsByDesignerId(id);
        }
    }
}
