using EternalCareHospital.Management.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EternalCareHospital.Management.Api.Extensions
{
    public static class ManagementDbContextExtensions
    {
        public static void EnsureDbIsCreated(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<ManagementDbContext>();
            context.Database.EnsureCreated();
            context.Database.CloseConnection();
        }
    }
}
