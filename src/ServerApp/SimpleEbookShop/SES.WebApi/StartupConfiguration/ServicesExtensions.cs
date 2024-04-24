using SES.Data.Repositories.Common;
using Solar.Data.Access.EF.Repositories.Common;

namespace SES.WebApi.StartupConfiguration;

public static class ServicesExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBooksRepository, BooksRepository>();

        return services;
    }
}