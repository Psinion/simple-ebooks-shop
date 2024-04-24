using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace SES.Application.StartupConfiguration;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { 
                Title = "SimpleEbookShop",
                Version = "v1" 
            });
        });
        
        /*services.AddDbContext<MainDbContext>(options =>
            options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"))
        );*/

        services.AddControllersWithViews()
            .AddJsonOptions(options =>
            {
                options
                    .JsonSerializerOptions
                    .ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

        services
            .AddRepositories();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Solar");
                options.RoutePrefix = string.Empty;
            });
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors();

        app.UseEndpoints(endpoints =>
            endpoints.MapControllers()
        );
    }
}
