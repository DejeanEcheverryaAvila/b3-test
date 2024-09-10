using System.Reflection;
using CDB_B3.Filters;
using CDB_B3.Interfaces;
using CDB_B3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;

namespace CDB_B3 {
    /// <summary>
    /// The main entry point class for the application.
    /// S1118 intentionally disabled for this class due to the fact that 
    /// a static Program class (that can't be instantiated), also can't be tested by xUnit.
    /// </summary>
    #pragma warning disable S1118
    public class Program
    {
        /// <summary>
        /// The entry point for the application.
        /// </summary>
        /// <param name="args">The command-line arguments passed to the application.</param>
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

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

                // Add our custom Filter to handle a default API Version field
                c.OperationFilter<ApiVersionOperationFilter>();
            });

            builder.Services.AddScoped<InvestmentIncomeTaxService>();

            // Create a factory method to select the right implementation for ICDBCalculator
            builder.Services.AddScoped<ICdbCalculator>(serviceProvider =>
            {
                // Manually inject the dependency
                var taxService = serviceProvider.GetRequiredService<InvestmentIncomeTaxService>();
                // Here we can use any criteria to select the implementation
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

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
    #pragma warning restore S1118
}
