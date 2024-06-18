using Microsoft.EntityFrameworkCore;
using Thunders.Infra.Context;

namespace Thunders.Api.Services;

public class DatabaseManagementService
{
    public static void MigrateDatabase(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        serviceScope.ServiceProvider.GetService<AppDbContext>().Database.Migrate();
    }
}
