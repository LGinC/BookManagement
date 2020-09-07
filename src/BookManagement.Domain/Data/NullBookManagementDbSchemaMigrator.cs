using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BookManagement.Data
{
    /* This is used if database provider does't define
     * IBookManagementDbSchemaMigrator implementation.
     */
    public class NullBookManagementDbSchemaMigrator : IBookManagementDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}