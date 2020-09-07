using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Users;

namespace BookManagement.Books
{
    /// <summary>
    /// 借阅服务
    /// </summary>
    public class LendManager : DomainService
    {
        private readonly IReadOnlyRepository<Book, long> _books;
        private readonly IRepository<Lend, long> _lends;
        private readonly ICurrentUser _currentUser;

        public LendManager(IRepository<Lend, long> lends, IReadOnlyRepository<Book, long> books, ICurrentUser currentUser)
        {
            _lends = lends;
            _books = books;
            _currentUser = currentUser;
        }

        public async Task LendAsync(long bookId, int quantity)
        {
            var book = _books.GetAsync(bookId);

            //借阅限制   已借阅未归还则不能再借
            if(await AsyncExecuter.AnyAsync(_lends, 
                l => l.CreatorId.HasValue && l.CreatorId.Value == _currentUser.GetId() &&
                l.State != LendState.Return))
            {

            }
        }
    }
}
