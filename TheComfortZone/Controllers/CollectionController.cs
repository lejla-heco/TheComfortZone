using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Administrator")]
        public override async Task<CollectionResponse> Insert([FromBody] CollectionUpsertRequest insert)
        {
            return await base.Insert(insert);
        }

        [Authorize(Roles = "Administrator")]
        public override async Task<CollectionResponse> Update(int id, [FromBody] CollectionUpsertRequest update)
        {
            return await base.Update(id, update);
        }

        [NonAction]
        public override async Task<string> Delete([FromBody] int id)
        {
            return await base.Delete(id);
        }

        [HttpGet("collections-by-designer-id/{id}")]
        public async Task<List<DTO.Collection.CollectionResponse>> GetCollectionsByDesignerId(int id)
        {
            return await collectionService.GetCollectionsByDesignerId(id);
        }
    }
}
