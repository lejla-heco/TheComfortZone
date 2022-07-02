﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheComfortZone.DTO.Charts;
using TheComfortZone.DTO.FurnitureItem;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    public class FurnitureItemController : BaseCRUDController<DTO.FurnitureItem.FurnitureItemResponse, DTO.FurnitureItem.FurnitureItemSearchRequest, DTO.FurnitureItem.FurnitureItemUpsertRequest, DTO.FurnitureItem.FurnitureItemUpsertRequest>
    {
        private readonly IFurnitureItemService furnitureItemService;
        public FurnitureItemController(IFurnitureItemService service) : base(service)
        {
            furnitureItemService = service;
        }

        [Authorize(Roles = "Administrator,Employee")]
        public override async Task<FurnitureItemResponse> Insert([FromBody] FurnitureItemUpsertRequest insert)
        {
            return await base.Insert(insert);
        }

        [Authorize(Roles = "Administrator,Employee")]
        public override async Task<FurnitureItemResponse> Update(int id, [FromBody] FurnitureItemUpsertRequest update)
        {
            return await base.Update(id, update);
        }

        [Authorize(Roles = "Administrator,Employee")]
        public override async Task<string> Delete(int id)
        {
            return await base.Delete(id);
        }

        [HttpGet("like/{userId}/{furnitureItemId}")]
        public async Task<string> likeFurnitureItem(int userId, int furnitureItemId)
        {
            return await furnitureItemService.likeFurnitureItem(userId, furnitureItemId);
        }

        [HttpGet("furniture-items-with-likes/{id}")]
        public async Task<List<FurnitureItemResponse>> getFurnitureItemsUserData(int id, [FromQuery] FurnitureItemSearchRequest search)
        {
            return await furnitureItemService.getFurnitureItemsUserData(id, search);
        }
    }
}
