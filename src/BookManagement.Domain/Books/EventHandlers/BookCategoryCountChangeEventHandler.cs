using System;
using System.Threading.Tasks;
using BookManagement.Events;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus;
using Volo.Abp.Uow;

namespace BookManagement.Books.EventHandlers
{
    class BookCategoryCountChangeEventHandler : ILocalEventHandler<BookCategoryCountChangedEto>, ITransientDependency
    {
        private readonly IRepository<BookCategory, long> _categories;

        public BookCategoryCountChangeEventHandler(IRepository<BookCategory, long> categories)
        {
            _categories = categories;
        }

        [UnitOfWork]
        public virtual async Task HandleEventAsync(BookCategoryCountChangedEto eventData)
        {
            var category = await _categories.GetAsync(eventData.Id);
            if (eventData.IsAdd)
            {
                category.AddCount(eventData.Count);
            }
            else
            {
                category.SubtractCount(eventData.Count);
            }
            Console.WriteLine($"{category.Name} 分类 下属图书数量变化:{(eventData.IsAdd ? eventData.Count : -eventData.Count)}");
        }
    }
}
