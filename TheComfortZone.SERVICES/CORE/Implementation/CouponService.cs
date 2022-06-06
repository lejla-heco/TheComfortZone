using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Coupon;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.DAO;
using TheComfortZone.SERVICES.DAO.Model;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class CouponService : BaseCRUDService<CouponResponse, DAO.Model.Coupon, CouponSearchRequest, CouponUpsertRequest, CouponUpsertRequest>, ICouponService
    {
        public CouponService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Coupon> IncludeList(IQueryable<Coupon> query)
        {
            query = query.Include(x => x.User);
            return query;
        }
    }
}
