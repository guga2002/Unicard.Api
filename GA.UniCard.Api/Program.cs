using GA.UniCard.Api.CustomMiddlwares;
using GA.UniCard.Application.Mapper;
using GA.UniCard.Domain.Data;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog.Web;
using System.Reflection;
using GA.UniCard.Domain.Interfaces;
using GA.UniCard.Infrastructure.Repositories;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Services;
using GA.UniCard.Infrastructure.UnitOfWork;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(DateTime.Now);
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ApiVersionReader = ApiVersionReader.Combine(
            new UrlSegmentApiVersionReader(),
            new HeaderApiVersionReader("X-Api-Version"));
    });

    #region Swagger config
    builder.Services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "UniCard Georgia",
            Description = "Exercise for Unicard Georgia , RestFull Api",
            TermsOfService = new Uri("https://github.com/guga2002/Unicard.Api/blob/main/README.md"),
            Contact = new OpenApiContact
            {
                Name = "Contact Me",
                Url = new Uri("https://www.linkedin.com/in/guga-apkhazava-938a40237/")
            },
            License = new OpenApiLicense
            {
                Name = "License, Source Code",
                Url = new Uri("https://github.com/guga2002/Unicard.Api")
            }
        });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        opt.IncludeXmlComments(xmlPath);
    });
    #endregion


    builder.Services.AddDbContext<UniCardDbContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DapperConnection"));
    });
    builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

    builder.Services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<IOrderRepository, OrderRepository>(); 
    builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();

    builder.Services.AddScoped<IOrderService, OrderServices>();
    builder.Services.AddScoped<IOrderItemServices,OrderItemServices>();
    builder.Services.AddScoped<IUserService,UserServices>();
    builder.Services.AddScoped<IproductServices, ProductServices>();

    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
    builder.Host.UseNLog();

    var app = builder.Build();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Uni Card Georgia v1");
        });
    }
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseMiddleware<ExceptionMiddleware>();
    app.UseMiddleware<LoggingMiddleware>();
    app.UseMiddleware<RateLimitingMiddleware>();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}