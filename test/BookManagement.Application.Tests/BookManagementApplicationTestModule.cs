using Volo.Abp.Modularity;

namespace BookManagement
{
    [DependsOn(
        typeof(BookManagementApplicationModule),
        typeof(BookManagementDomainTestModule)
        )]
    public class BookManagementApplicationTestModule : AbpModule
    {

    }
}