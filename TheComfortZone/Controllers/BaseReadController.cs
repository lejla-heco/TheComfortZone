using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BaseReadController<T, TSearch> : ControllerBase where T : class where TSearch : class
    {
        public readonly IReadService<T, TSearch> service;

        public BaseReadController(IReadService<T, TSearch> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<T> Get([FromQuery] TSearch search = null)
        {
            return service.Get(search);
        }

        [HttpGet("{id}")]
        public T GetById(int id)
        {
            return service.GetById(id);
        }
    }
}
