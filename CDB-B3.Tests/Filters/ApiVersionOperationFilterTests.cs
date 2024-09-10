using Xunit;
using CDB_B3.Filters;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Any;

namespace CDB_B3.Tests.Filters
{
    public class ApiVersionOperationFilterTests
    {
        [Fact]
        public void Apply_ShouldSetVersionParameter()
        {
            // Arrange
            var filter = new ApiVersionOperationFilter();
            var operation = new OpenApiOperation();
            operation.Parameters = new List<OpenApiParameter>();
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "version",
                In = ParameterLocation.Path,
                Description = "API version",
                Required = true,
                Schema = new OpenApiSchema
                {
                     Type = "string",
                    Default = new OpenApiString("1"), // Default version
                    Enum = new List<IOpenApiAny>
                    {
                        new OpenApiString("1"), // Allowed versions
                        // Here we can add more versions
                    }
                }
            });

            // Crie uma descrição de API simples
            var apiDescription = new ApiDescription
            {
                ActionDescriptor = new ControllerActionDescriptor
                {
                    ControllerName = "CDBController",
                    ActionName = "CalculateCDB"
                },
                HttpMethod = "POST",
                RelativePath = "/api/v1/cdb"
            };


            var context = new OperationFilterContext(apiDescription, null, null, null);

            // Act
            filter.Apply(operation, context);

            // Assert
            var versionParameter = operation.Parameters.SingleOrDefault(p => p.Name == "version" && p.In == ParameterLocation.Path);
            
            Assert.NotNull(versionParameter);
            Assert.Equal("API version", versionParameter.Description);
            Assert.True(versionParameter.Required);
        }

    }
}
