using BookManagement.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace BookManagement.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(BookManagementEntityFrameworkCoreDbMigrationsModule),
        typeof(BookManagementApplicationContractsModule)
        )]
    public class BookManagementDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
