using BookManagement.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BookManagement.EntityFrameworkCore
{
    public static class BookManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureBookManagement(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<Book>(b =>
            {
                b.ToTable("Books");
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(e => e.Author).IsRequired().HasMaxLength(BookManagementConsts.NameMaxLength);
                b.Property(e => e.CategoryName).IsRequired().HasMaxLength(BookManagementConsts.NameMaxLength);
                b.Property(e => e.Languge).HasMaxLength(BookManagementConsts.ShortNameMaxLength);
                b.Property(e => e.Name).IsRequired().HasMaxLength(BookManagementConsts.NameMaxLength);
                b.Property(e => e.Publisher).HasMaxLength(BookManagementConsts.NameMaxLength);
                b.Property(e => e.Description).HasMaxLength(BookManagementConsts.DescMaxLenth);
                b.Property(e => e.Image).HasMaxLength(BookManagementConsts.ImageMaxLenth);
            });

            builder.Entity<BookCategory>(b =>
            {
                b.ToTable("BookCategories");
                b.ConfigureCreationAuditedAggregateRoot();
                b.Property(e => e.Code).IsRequired().HasMaxLength(BookManagementConsts.CodeMaxLength);
                b.Property(e => e.Icon).HasMaxLength(BookManagementConsts.ImageMaxLenth);
                b.Property(e => e.Name).IsRequired().HasMaxLength(BookManagementConsts.NameMaxLength);
                b.Property(e => e.Location).HasMaxLength(BookManagementConsts.DescMaxLenth);
                b.Property(e => e.Description).HasMaxLength(BookManagementConsts.DescMaxLenth);
            });

            builder.Entity<Lend>(b =>
            {
                b.ToTable("Lends");
                b.ConfigureFullAuditedAggregateRoot();
                b.Property(e => e.BookName).IsRequired().HasMaxLength(BookManagementConsts.NameMaxLength);
                b.Property(e => e.Remark).IsRequired().HasMaxLength(BookManagementConsts.RemarkMaxLength);
            });

            builder.Entity<LendLog>(b =>
            {
                b.ToTable("LendLogs");
                b.Property(e => e.Remark).IsRequired().HasMaxLength(BookManagementConsts.RemarkMaxLength);
            });
        }
    }
}