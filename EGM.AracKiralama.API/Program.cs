﻿using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
//API servislerini eklemek için
builder.Services.AddControllers();

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





var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapDefaultControllerRoute();

app.Run();
