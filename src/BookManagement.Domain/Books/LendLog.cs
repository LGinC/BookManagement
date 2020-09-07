using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace BookManagement.Books
{
    /// <summary>
    /// 借阅历史
    /// </summary>
    public class LendLog : Entity<long>, IHasCreationTime
    {
        //public Guid UserId { get; private set; }

        //public long BookId { get; private set; }

        /// <summary>
        /// 借阅状态
        /// </summary>
        public LendState State { get; private set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; private set; }


        public DateTime CreationTime { get; set; }

        public LendLog(LendState state, string remark)
        {
            State = state;
            Remark = remark;
        }
    }
}
