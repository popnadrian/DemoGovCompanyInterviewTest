using DataAccessInterfaces;
using DomainLogic;
using EfDal;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace Api.Middleware
{
    public static class DiConfig
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<CompanyReadService>();
            services.AddTransient<CompanyWriteService>();
            services.AddTransient<ICompanyValidator, CompanyValidator>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddDbContext<CompanyDbContext>(options =>
            {
                options.UseSqlite($"Data Source=company.db");
            });


        }

        public static void InitDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            using var context = scope.ServiceProvider.GetRequiredService<CompanyDbContext>();

            context.Database.EnsureCreated();
        }
    }
}
