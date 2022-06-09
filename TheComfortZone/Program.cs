using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TheComfortZone.Authentication;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.CORE.Implementation;
using TheComfortZone.SERVICES.DAO;
using TheComfortZone.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(x =>
{
    //x.Filters.Add<ErrorFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
            },
            new string[]{}
        }
    });
});

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IFurnitureItemService, FurnitureItemService>();
builder.Services.AddTransient<ISpaceService, SpaceService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IDesignerService, DesignerService>();
builder.Services.AddTransient<ICollectionService, CollectionService>();
builder.Services.AddTransient<IMetricUnitService, MetricUnitService>();
builder.Services.AddTransient<IMaterialService, MaterialService>();
builder.Services.AddTransient<IColorService, ColorService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderItemService, OrderItemService>();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();
builder.Services.AddTransient<ICouponService, CouponService>();
builder.Services.AddTransient<IChartService, ChartService>();

builder.Services.AddAutoMapper(typeof(IUserService));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TheComfortZoneContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
