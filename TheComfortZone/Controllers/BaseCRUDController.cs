using Microsoft.AspNetCore.Mvc;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseReadController<T, TSearch> where T : class where TSearch : BaseSearchObject where TInsert : class where TUpdate : class
    {
        public readonly ICRUDService<T, TSearch, TInsert, TUpdate> crudService;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            this.crudService = service;
        }

        [HttpPost]
        public async virtual Task<T> Insert([FromBody] TInsert insert)
        {
            return await crudService.Insert(insert);
        }

        [HttpPut("{id}")]
        public async virtual Task<T> Update(int id, [FromBody] TUpdate update)
        {
            return await crudService.Update(id, update);
        }

        [HttpDelete("{id}")]
        public async virtual Task<string> Delete(int id)
        {
            return await crudService.Delete(id);
        }
    }
}
