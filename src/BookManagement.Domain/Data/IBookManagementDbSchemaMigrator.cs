using System.Threading.Tasks;

namespace BookManagement.Data
{
    public interface IBookManagementDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
