using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace BookManagement.EntityFrameworkCore
{
    [DependsOn(
        typeof(BookManagementEntityFrameworkCoreModule)
        )]
    public class BookManagementEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BookManagementMigrationsDbContext>();
        }
    }
}
