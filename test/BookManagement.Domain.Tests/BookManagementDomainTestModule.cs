using BookManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BookManagement
{
    [DependsOn(
        typeof(BookManagementEntityFrameworkCoreTestModule)
        )]
    public class BookManagementDomainTestModule : AbpModule
    {

    }
}