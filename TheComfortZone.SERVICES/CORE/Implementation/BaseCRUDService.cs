using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.DAO;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class BaseCRUDService<T, TDb, TSearch, TInsert, TUpdate> : BaseReadService<T, TDb, TSearch>, ICRUDService<T, TSearch, TInsert, TUpdate> where T : class where TDb : class where TSearch : BaseSearchObject where TInsert : class where TUpdate : class
    {
        public BaseCRUDService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async virtual Task<T> Insert(TInsert insert)
        {
            ValidateInsert(insert);

            var entity = mapper.Map<TDb>(insert);
            context.Set<TDb>().Add(entity);
            BeforeInsert(insert, entity);
            context.SaveChanges();
            return mapper.Map<T>(entity);
        }

        public virtual void BeforeInsert(TInsert insert, TDb entity) { }

        public async virtual Task<T> Update(int id, TUpdate update)
        {
            ValidateUpdate(id, update);

            var entity = context.Set<TDb>().Find(id);
            if (entity != null)
            {
                mapper.Map(update, entity);
                BeforeUpdate(entity, update);
            }
            else
            {
                return null;
            }

            context.SaveChanges();
            return mapper.Map<T>(entity);
        }

        public virtual void BeforeUpdate(TDb entity, TUpdate update) { }

        public async virtual Task<string> Delete(int id)
        {
            TDb entity = context.Set<TDb>().Find(id);

            BeforeDelete(id);

            context.Set<TDb>().Remove(entity);
            context.SaveChanges();

            string response = $"{typeof(TDb).Name} deleted!";

            return response;
        }

        public virtual void BeforeDelete(int id) { }

        /** VALIDATION **/
        public virtual void ValidateInsert(TInsert insert) { }
        public virtual void ValidateUpdate(int id, TUpdate update) { }
    }
}
