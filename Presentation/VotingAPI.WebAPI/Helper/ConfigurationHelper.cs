using VotingAPI.Application;
using VotingAPI.Infrastructure;
using VotingAPI.Infrastructure.Services.Storage.Azure;
using VotingAPI.ObsService;
using VotingAPI.Persistence;

namespace VotingAPI.WebAPI.Helper
{
    public static class ConfigurationHelper
    {
        public static void ConfigureService(this IServiceCollection services)
        {
            services.AddPersistenceDI();
            services.AddApplicationServices();
            services.AddInfrastructureServices();
            services.AddStorage<AzureStorage>();
            services.AddApiVersioning(_ =>
            {
                _.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                _.AssumeDefaultVersionWhenUnspecified = true;
            });
            services.AddObsServices();
            //services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

        }
    }
}
