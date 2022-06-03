using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.SERVICES.API
{
    public interface ICRUDService<T, TSearch, TInsert, TUpdate> : IReadService<T, TSearch> where T : class where TSearch : BaseSearchObject where TInsert : class where TUpdate : class
    {
        public Task<T> Insert(TInsert insert);
        public Task<T> Update(int id, TUpdate update);
        public Task<string> Delete(int id);
    }
}
