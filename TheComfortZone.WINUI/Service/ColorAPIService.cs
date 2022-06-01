using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.WINUI.Service
{
    public class ColorAPIService : BaseReadAPIService<DTO.Color.ColorResponse, BaseSearchObject>
    {
        private const string API_ROUTE = "Color";
        public ColorAPIService() : base(API_ROUTE)
        {
        }
    }
}
