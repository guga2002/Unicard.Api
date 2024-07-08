#region Usings
using GA.UniCard.Api.CustomMiddlwares;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Interfaces.Identity;
using GA.UniCard.Application.Mapper;
using GA.UniCard.Application.Services;
using GA.UniCard.Application.Services.Identity;
using GA.UniCard.Domain.Data;
using GA.UniCard.Domain.Entities;
using GA.UniCard.Domain.Identity;
using GA.UniCard.Domain.Interfaces;
using GA.UniCard.Infrastructure.Repositories;
using GA.UniCard.Infrastructure.UniteOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using NLog.Web;
using System.Reflection;
using System.Text;
#endregion
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddMemoryCache();

    #region AddApiVersioning
    builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(DateTime.Now);
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ApiVersionReader = ApiVersionReader.Combine(
            new UrlSegmentApiVersionReader(),
            new HeaderApiVersionReader("X-Api-Version"));
    });
    #endregion

    #region Swagger config
    builder.Services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "UniCard Georgia API",
            Description = "RESTful API using C# .NET 8, Dapper, AutoMapper, NLog for\r\nlogging, FluentValidation for input validation",
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

        opt.EnableAnnotations();

        opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Scheme = "Bearer",
            Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...\""
        });

        opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    });
    #endregion

    #region AddDbContext
    builder.Services.AddDbContext<UniCardDbContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("DapperConnection"));
    });
    #endregion

    #region Services LifeTime
    builder.Services.AddScoped<UserManager<Person>>();
    builder.Services.AddScoped<RoleManager<IdentityRole>>();
    builder.Services.AddScoped<SignInManager<Person>>();

    builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

    builder.Services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();

    builder.Services.AddScoped<IOrderService, OrderServices>();
    builder.Services.AddScoped<IOrderItemServices, OrderItemServices>();
    builder.Services.AddScoped<IUserService, UserServices>();
    builder.Services.AddScoped<IproductServices, ProductServices>();

    builder.Services.AddScoped<IAdminPanelServices, AdminPanelServices>();
    builder.Services.AddScoped<IPersonServices, PersonServices>();
    builder.Services.AddScoped<IJwtService, JwtService>();
    #endregion

    #region AutoMapper
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
    #endregion

    #region NLogConfig
    builder.Services.AddLogging(logging =>
    {
        logging.ClearProviders();
        logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
        logging.AddNLog(builder.Configuration.GetSection("v"));
    });
    builder.Host.UseNLog();
    #endregion

    #region Identity
    builder.Services.AddIdentity<Person, IdentityRole>()
        .AddEntityFrameworkStores<UniCardDbContext>()
        .AddDefaultTokenProviders();
    #endregion

    #region Authentification
    var jwtSettings = builder.Configuration.GetSection("JwtSettings");
    var validateJwt = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"] ?? throw new ArgumentException("security key can not be null"))),
    };


    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(jwt =>
    {

        jwt.SaveToken = true;
        jwt.TokenValidationParameters = validateJwt;
    });
    builder.Services.AddSingleton(validateJwt);
    #endregion

    #region Cors
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("RequestPipeline",
            builder =>
            {
                if (builder == null) throw new ArgumentNullException(nameof(builder));
                builder.WithOrigins()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
    });
    #endregion

    var app = builder.Build();

    #region Use Swagger
    if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Uni Card Georgia v1");
        });
    }
    #endregion


    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    #region Custom Middlwares
    app.UseMiddleware<ExceptionMiddleware>();
    app.UseMiddleware<LoggingMiddleware>();
    app.UseMiddleware<RateLimitingMiddleware>();
    #endregion

    app.MapControllers();
    app.UseCors("RequestPipeline");
    app.Run();
}
finally
{
    NLog.LogManager.Shutdown();
}