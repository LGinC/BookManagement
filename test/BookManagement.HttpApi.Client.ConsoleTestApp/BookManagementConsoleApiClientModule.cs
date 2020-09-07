using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace BookManagement.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(BookManagementHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class BookManagementConsoleApiClientModule : AbpModule
    {
        
    }
}
