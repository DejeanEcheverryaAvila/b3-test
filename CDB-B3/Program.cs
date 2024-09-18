using System.Reflection;
using CDB_B3.Filters;
using CDB_B3.Interfaces;
using CDB_B3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;

namespace CDB_B3 {
    #pragma warning disable S1118
    public class Program
    {
        private static string _frontendURL = "https://localhost:4200";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            // Configurar CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    policyBuilder =>
                    {
                        policyBuilder.WithOrigins(_frontendURL)
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });

            builder.Services.AddControllers();

            // Configuração do Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CDB - B3",
                    Version = "v1",
                    Description = "Certificate of Deposit (CDB) calculator for B3",
                    Contact = new OpenApiContact
                    {
                        Name = "Dejean Echeverrya Ávila",
                        Email = ""
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    },
                });

                if (File.Exists(xmlPath))
                    c.IncludeXmlComments(xmlPath);

                c.OperationFilter<ApiVersionOperationFilter>();
            });

            builder.Services.AddScoped<InvestmentIncomeTaxService>();

            builder.Services.AddScoped<ICdbCalculator>(serviceProvider =>
            {
                var taxService = serviceProvider.GetRequiredService<InvestmentIncomeTaxService>();
                return new SimpleCdbCalculatorService(taxService);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Habilitar CORS
            app.UseCors("AllowSpecificOrigin");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
    #pragma warning restore S1118
}