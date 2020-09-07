using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace BookManagement.EntityFrameworkCore
{
    public static class BookManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureBookManagement(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(BookManagementConsts.DbTablePrefix + "YourEntities", BookManagementConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}