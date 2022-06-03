using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.CORE.Utils;
using TheComfortZone.SERVICES.DAO;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class BaseReadService<T, TDb, TSearch> : IReadService<T, TSearch> where T : class where TDb : class where TSearch : BaseSearchObject
    {
        public TheComfortZoneContext context { get; set; }
        public IMapper mapper { get; set; }

        public BaseReadService(TheComfortZoneContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public virtual async Task<IEnumerable<T>> Get(TSearch search = null)
        {
            IQueryable<TDb> query = context.Set<TDb>().AsQueryable();

            query = IncludeList(query);
            query = AddFilter(query, search);

            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                query = query.Skip(search.Page.Value * search.PageSize.Value).Take(search.PageSize.Value);
            }

            return mapper.Map<List<T>>(query.ToList());

        }

        public virtual IQueryable<TDb> IncludeList(IQueryable<TDb> query)
        {
            return query;
        }

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch search = null)
        {
            return query;
        }

        public async Task<T> GetById(int id)
        {
            ValidateGetById(id);
            var entity = context.Set<TDb>().Find(id);
            return mapper.Map<T>(entity);
        }

        /** VALIDATION **/
        public virtual void ValidateGetById(int id)
        {
            if (context.Set<TDb>().Find(id) == null)
                throw new UserException($"{typeof(TDb).Name} with specified ID does not exist!");
        }
    }
}
