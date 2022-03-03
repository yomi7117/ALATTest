using ALATTest.Domain;
using ALATTest.Domain.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ALATTest.Domain
{
    public static class PrepDatabaseData
    {
        public static void PrepDataSeeding(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<ALATDBContext>());
        }

        private static void SeedData(ALATDBContext context)
        {
           
            SeedingService.AutoSeedStateandLGA(context);
       
        
        }
    }
}
