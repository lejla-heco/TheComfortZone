using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Coupon;

namespace TheComfortZone.WINUI.Service
{
    public class CouponAPIService : BaseAPIService<CouponResponse, CouponSearchRequest, CouponUpsertRequest, CouponUpsertRequest>
    {
        private const string API_ROUTE = "Coupon";
        public CouponAPIService() : base(API_ROUTE)
        {
        }
    }
}
