using EternalCareHospital.Clinic.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EternalCareHospital.Clinic.Api.Extensions
{
    public static class ClinicDbContextExtensions
    {
        public static void EnsureDbIsCreated(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<ClinicDbContext>();
            context.Database.EnsureCreated();
            context.Database.CloseConnection();
        }
    }
}
