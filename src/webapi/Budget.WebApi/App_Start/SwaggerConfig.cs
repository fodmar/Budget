using System.Web.Http;
using System.Web.Http.Description;
using WebActivatorEx;
using Budget.WebApi;
using Swashbuckle.Application;
using System.Linq;

namespace Budget.WebApi
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                c.ResolveConflictingActions(apiDescriptions =>
                {
                    return apiDescriptions.First();
                });
            })
            .EnableSwaggerUi(c =>
            {
                c.DocumentTitle("Budget API Swagger UI");
            });
        }
    }
}
