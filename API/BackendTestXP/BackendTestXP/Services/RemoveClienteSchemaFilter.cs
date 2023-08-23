using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BackendTestXP.Services
{
    public class RemoveEntitiesSchemaFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (swaggerDoc.Components.Schemas.ContainsKey("Cliente"))
            {
                swaggerDoc.Components.Schemas.Remove("Cliente");
            }

            if (swaggerDoc.Components.Schemas.ContainsKey("Email"))
            {
                swaggerDoc.Components.Schemas.Remove("Email");
            }

            if (swaggerDoc.Components.Schemas.ContainsKey("Endereco"))
            {
                swaggerDoc.Components.Schemas.Remove("Endereco");
            }

        }
    }
}
