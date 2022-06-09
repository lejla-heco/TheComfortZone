using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Charts;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.CORE.Utils;
using TheComfortZone.SERVICES.DAO;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class ChartService : IChartService
    {
        public TheComfortZoneContext context { get; set; }
        public IMapper mapper { get; set; }

        public ChartService(TheComfortZoneContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<LineChartListResponse>> GetBestSellingItems(string space)
        {
            var lastYear = DateTime.Now.Year - 1;

            var query = context.OrderItems.Include(x => x.FurnitureItem)
                .ThenInclude(x => x.Category)
                .ThenInclude(x => x.Space)
                .Include(x => x.Order)
                .Where(x => x.FurnitureItem.Category.Space.Name.ToLower() == space.ToLower())
                .Select(x => new {
                    furnitureId = x.FurnitureItemId,
                    furnitureName = x.FurnitureItem.Name,
                    numberOfOrders = x.FurnitureItem.OrderItems
                        .Where(y => y.FurnitureItemId == x.FurnitureItemId)
                        .Sum(y => y.OrderQuantity),
                    year = x.Order.OrderDate.Value.Year,
                })
                .Where(x => x.year == lastYear)
                .Distinct()
                .OrderByDescending(x => x.numberOfOrders)
                .Take(10);

            var list = query.ToList();

            var furnitureIdList = list.Select(x => x.furnitureId).ToList();

            var query2 = context.OrderItems.Where(oi => furnitureIdList.Contains(oi.FurnitureItemId))
                .Include(x => x.FurnitureItem)
                .ThenInclude(x => x.Category)
                .ThenInclude(x => x.Space)
                .Include(x => x.Order)
                .Where(x => x.FurnitureItem.Category.Space.Name.ToLower() == space.ToLower())
                .Select(x => new
                {
                    furnitureId = x.FurnitureItemId,
                    furnitureName = x.FurnitureItem.Name,
                    numberOfOrders = x.FurnitureItem.OrderItems
                        .Where(y => y.FurnitureItemId == x.FurnitureItemId)
                        .Where(y => y.Order.OrderDate.Value.Month == x.Order.OrderDate.Value.Month)
                        .Sum(y => y.OrderQuantity),
                    year = x.Order.OrderDate.Value.Year,
                    month = x.Order.OrderDate.Value.Month,
                })
                .Where(x => x.year == lastYear)
                .Distinct()
                .OrderByDescending(x => x.numberOfOrders);

            var furnitureItems = query2.ToList();

            List<LineChartListResponse> chartResponse = new List<LineChartListResponse>();

            for (int x = 0; x < furnitureIdList.Count; x++)
            {
                var id = furnitureIdList[x];
                LineChartListResponse series = new LineChartListResponse();
                series.FurnitureName = furnitureItems.First(l => l.furnitureId == id).furnitureName;

                for (int i = 1; i <= 12; i++)
                {
                    if (!furnitureItems.Where(l => l.month == i && l.furnitureId == id).Any())
                        series.ChartData.Add(new LineChartResponse()
                        {
                            YValue = 0,
                            XValue = i,
                        });
                    else
                        series.ChartData.Add(new LineChartResponse()
                        {
                            YValue = (int)furnitureItems.SingleOrDefault(l => l.month == i && l.furnitureId == id).numberOfOrders,
                            XValue = i,
                        });
                }

                chartResponse.Add(series);
            }

            return chartResponse;
        }

        public async Task<List<SalesResponse>> GetSalesByPeriod(DateRangeSearchRequest search = null)
        {
            if (search?.FromDate.HasValue == true && search?.ToDate.HasValue == true
                && search.FromDate.Value.Date.CompareTo(search.ToDate.Value.Date) > 0)
                throw new UserException("Start date must be earlier than end date!");

            var queryOrders = context.Orders.Include(x => x.User).Include(x => x.Employee).AsQueryable();
            var queryAppointments = context.Appointments.Include(x => x.User).Include(x => x.Employee).AsQueryable();

            if (search?.FromDate.HasValue == true && search?.FromDate != default(DateTime))
            {
                queryOrders = queryOrders.Where(x => x.OrderDate.Value.Date.CompareTo(search.FromDate.Value.Date) >= 0);
                queryAppointments = queryAppointments.Where(x => x.AppointmentDate.Value.Date.CompareTo(search.FromDate.Value.Date) >= 0);
            }

            if (search?.ToDate.HasValue == true && search?.ToDate != default(DateTime))
            {
                queryOrders = queryOrders.Where(x => x.OrderDate.Value.Date.CompareTo(search.ToDate.Value.Date) <= 0);
                queryAppointments = queryAppointments.Where(x => x.AppointmentDate.Value.Date.CompareTo(search.ToDate.Value.Date) <= 0);
            }

            var queryOrdersList = queryOrders.ToList();
            var queryAppointmentsList = queryAppointments.ToList();

            List<SalesResponse> salesOrders = mapper.Map<List<SalesResponse>>(queryOrdersList);
            List<SalesResponse> salesAppointments = mapper.Map<List<SalesResponse>>(queryAppointmentsList);

            salesOrders.AddRange((IEnumerable<SalesResponse>)salesAppointments);

            var response = salesOrders.Select(x => new SalesResponse()
            {
                Customer = x.Customer,
                Employee = x.Employee,
                TotalPrice = salesOrders
                .Where(y => y.Customer == x.Customer)
                .Where(y => y.Employee == x.Employee)
                .Where(y => y.Date.Date == x.Date.Date)
                .Sum(y => y.TotalPrice),
                Date = x.Date.Date,
            })
                .GroupBy(x => new { x.Customer, x.Employee, x.Date })
                .Select(x => x.First())
                .OrderByDescending(x => x.Date);

            return response.ToList();
        }

        public async Task<List<PieChartEmployeeResponse>> GetIncomePerEmployee(DateRangeSearchRequest search = null)
        {
            if (search?.FromDate.HasValue == true && search?.ToDate.HasValue == true
                && search.FromDate.Value.Date.CompareTo(search.ToDate.Value.Date) > 0)
                throw new UserException("Start date must be earlier than end date!");

            List<PieChartEmployeeResponse> response = new List<PieChartEmployeeResponse>();

            if (search?.FromDate == null && search?.ToDate == null)
                response = context.Users
                    .Include(x => x.Role)
                    .Include(x => x.OrderEmployees)
                    .Include(x => x.AppointmentEmployees)
                    .Where(x => x.Role.Name == UserType.Employee.ToString())
                    .Select(x => new PieChartEmployeeResponse()
                    {
                        Employee = $"{x.FirstName} {x.LastName}",
                        NumberOfSalesMade = x.OrderEmployees.Count,
                        NumberOfAppointments = x.AppointmentEmployees.Count,
                        Income = (float)x.AppointmentEmployees.Sum(y => y.TotalPrice) + (float)x.OrderEmployees.Sum(y => y.TotalPrice)
                    }).ToList();


            if (search?.FromDate != null && search?.ToDate != null)
            {
                response = context.Users
                    .Include(x => x.Role)
                    .Include(x => x.OrderEmployees)
                    .Include(x => x.AppointmentEmployees)
                    .Where(x => x.Role.Name == UserType.Employee.ToString())
                    .Select(x => new PieChartEmployeeResponse()
                    {
                        Employee = $"{x.FirstName} {x.LastName}",
                        NumberOfSalesMade = x.OrderEmployees.Where(y => y.OrderDate.Value.Date >= search.FromDate.Value.Date && y.OrderDate.Value.Date <= search.ToDate.Value.Date).Count(),
                        NumberOfAppointments = x.AppointmentEmployees.Where(y => y.AppointmentDate.Value.Date >= search.FromDate.Value.Date && y.AppointmentDate.Value.Date <= search.ToDate.Value.Date).Count(),
                        Income = (float)x.AppointmentEmployees
                        .Where(y => y.AppointmentDate.Value.Date >= search.FromDate.Value.Date && y.AppointmentDate.Value.Date <= search.ToDate.Value.Date)
                        .Sum(y => y.TotalPrice) +
                        (float)x.OrderEmployees
                        .Where(y => y.OrderDate.Value.Date >= search.FromDate.Value.Date && y.OrderDate.Value.Date <= search.ToDate.Value.Date)
                        .Sum(y => y.TotalPrice)
                    }).ToList();
            }

            return response;
        }
    }
}
