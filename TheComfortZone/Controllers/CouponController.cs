using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheComfortZone.DTO.Coupon;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    public class CouponController : BaseCRUDController<CouponResponse, CouponSearchRequest, CouponUpsertRequest, CouponUpsertRequest>
    {
        private readonly ICouponService couponService;
        public CouponController(ICouponService service) : base(service)
        {
            couponService = service;
        }

        [Authorize(Roles = "Administrator,User")]
        public override async Task<IEnumerable<CouponResponse>> Get([FromQuery] CouponSearchRequest search = null)
        {
            return await base.Get(search);
        }

        [Authorize(Roles = "Administrator")]
        public override async Task<CouponResponse> Insert([FromBody] CouponUpsertRequest insert)
        {
            return await base.Insert(insert);
        }

        [Authorize(Roles = "User")]
        public override async Task<CouponResponse> Update(int id, [FromBody] CouponUpsertRequest update)
        {
            return await base.Update(id, update);
        }

        [NonAction]
        public override async Task<string> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}
