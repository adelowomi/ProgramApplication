using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

namespace ProgramApplication;

public static class AppServiceExtension
{
    public static void AddAppService(this IServiceCollection services, IConfiguration configuration)
    {
        // configure app settings
        services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
        //get app settings
        var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();


        // configure cosmos db
        services.AddDbContext<Context>(options =>
        {
            options.UseCosmos(appSettings.CosmosDBEndpoint, appSettings.CosmosDBKey, databaseName: "ProgramApplication", x =>
            {
                x.HttpClientFactory(() =>
                {
                    HttpMessageHandler httpMessageHandler = new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    };

                    return new HttpClient(httpMessageHandler);
                });
                x.ConnectionMode(ConnectionMode.Gateway);
            });

        });

        // configure generic usable repository
        services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        // configure services
        services.AddTransient<IQuestionTypeService, QuestionTypeService>();
        services.AddTransient<IProgramService, ProgramService>();
    }
}
