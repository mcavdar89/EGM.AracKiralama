using Castle.DynamicProxy;
using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.BL.Concretes;
using EGM.AracKiralama.DAL.Abstracts;
using EGM.AracKiralama.DAL.Concretes;
using EGM.AracKiralama.DAL.Contexts;
using EGM.AracKiralama.Model.Profiles;
using Infra.API.Middlewares;
using Infra.Extensions;
using Infrastructure.Cache;
using Infrastructure.Interceptors;
using Infrastructure.Model.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Transactions;


//var proxyGenetor = new ProxyGenerator();


var builder = WebApplication.CreateBuilder(args);
//API servislerini eklemek için
builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidAudience = jwtSettings.Audience,
            ValidIssuer = jwtSettings.Issuer,
            ValidateLifetime = true,
            IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
        };


    });
builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation    
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "EGM Proje",
        Description = " Swagger",
    });
    // To Enable authorization using Swagger (JWT)    
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Token Bilgisini Giriniz: \r\n\r\nÖrnek Kullanım: \r\nBearer eyJhbGciOiJIUzI1NiIsInR5...",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
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

builder.Services.AddDbContext<AracKiralamaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AracKiralamaConnection"));
});
#region LogService ayarları
builder.Services.AddEGMLog(builder.Configuration.GetConnectionString("LogDbConnection"));
#endregion

//builder.Services.AddTransient<CachingInterceptor>();

//builder.Services.AddInRedisCache(builder.Configuration.GetSection("RedisConfiguration").Get<RedisConfiguration>());
builder.Services.AddInMemoryCache();


builder.Services.AddAutoMapper(typeof(AracKiralamaProfile));


builder.Services.AddScoped<IAracKiralamaRepository, AracKiralamaRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IOASService, OASService>();

//builder.Services.AddProxiedServices(proxyGenetor);

TransactionManager.ImplicitDistributedTransactions = true;

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<LogMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
