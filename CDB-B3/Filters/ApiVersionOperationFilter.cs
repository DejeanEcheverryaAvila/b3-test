using System;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CDB_B3.Filters
{
    /// <summary>
    /// Implements the Swagger operation filter for API versioning.
    /// </summary>
    public class ApiVersionOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Applies the API versioning filter to the specified operation.
        /// </summary>
        /// <param name="operation">The operation to apply the filter to.</param>
        /// <param name="context">The context for the operation filter.</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Find the "version" parameter in the Path
            var versionParameter = operation.Parameters.SingleOrDefault(p => p.Name == "version" && p.In == ParameterLocation.Path);

            if (versionParameter != null)
            {
                // Replace the "version" parameter with the real version parameter
                versionParameter.Description = "API version";
                versionParameter.Required = true;
                versionParameter.Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("1"), // Default version
                    Enum = new List<IOpenApiAny>
                    {
                        new OpenApiString("1"), // Allowed versions
                        // Here we can add more versions
                    }
                };
            }
        }
    }
}
