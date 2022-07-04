using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Coupon;

namespace TheComfortZone.SERVICES.API
{
    public interface ICouponService : ICRUDService<CouponResponse, CouponSearchRequest, CouponInsertRequest, CouponUpdateRequest>
    {
        public Task<List<CouponResponse>> GetCouponsByUserId(int id);
    }
}
