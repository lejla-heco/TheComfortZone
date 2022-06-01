using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.WINUI.Service
{
    public class MaterialAPIService : BaseReadAPIService<DTO.Material.MaterialResponse, BaseSearchObject>
    {
        private const string API_ROUTE = "Material";
        public MaterialAPIService() : base(API_ROUTE)
        {
        }
    }
}
