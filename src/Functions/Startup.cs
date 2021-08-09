using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.DataAccess;

[assembly: FunctionsStartup(typeof(Functions.Startup))]

namespace Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddVepDbRepository(builder.GetContext().Configuration);
        }
    }

    internal static class StartupExtensions
    {
        public static IServiceCollection AddVepDbRepository(this IServiceCollection services, IConfiguration configuration)
        {
            var vepDbConnectionString = configuration.GetConnectionString("VepDb");

            return services
                .AddScoped<IProcedureExecutor>(sp => new ProcedureExecutor(vepDbConnectionString))
                .AddScoped<IVepDbRepository, VepDbRepository>();
        }
    }
}
