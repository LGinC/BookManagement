using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Events;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus;
using Volo.Abp.Linq;
using Volo.Abp.Uow;

namespace BookManagement.Books.EventHandlers
{
    public class BookCategoryNameEventHandler : ILocalEventHandler<BookCategoryNameChangedEto>, ITransientDependency
    {
        private readonly IRepository<Book, long> _books;
        private readonly IAsyncQueryableExecuter _executer;

        public BookCategoryNameEventHandler(IRepository<Book, long> books, IAsyncQueryableExecuter executer)
        {
            _books = books;
            _executer = executer;
        }

        [UnitOfWork]
        public virtual async Task HandleEventAsync(BookCategoryNameChangedEto eventData)
        {
            Console.WriteLine($"id为{eventData.Id}的分类修改名称为:{eventData.Name}");
            var books = await _executer.ToListAsync(_books.Where(b => b.CategoryId == eventData.Id));
            foreach (var book in books)
            {
                book.SetCategory(eventData.Id, eventData.Name, false);
            }
        }
    }
}
