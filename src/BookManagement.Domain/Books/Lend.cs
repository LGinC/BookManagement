using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookManagement.Books
{
    /// <summary>
    /// 借阅
    /// </summary>
    public class Lend : FullAuditedAggregateRoot<long>
    {
        /// <summary>
        /// 图书id
        /// </summary>
        public long BookId { get; private set; }

        /// <summary>
        /// 书名
        /// </summary>
        public string BookName { get; private set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// 借出时间
        /// </summary>
        public DateTime LendTime { get; private set; }

        /// <summary>
        /// 应归还时间
        /// </summary>
        public DateTime ShouldReturnTime { get; private set; }

        /// <summary>
        /// 归还时间
        /// </summary>
        public DateTime? ReturnTime { get; private set; }

        /// <summary>
        /// 是否超期
        /// </summary>
        /// <param name="now">现在时间</param>
        /// <returns></returns>
        public bool IsOutOfDate(DateTime now) => State != LendState.Return && ShouldReturnTime < now;

        /// <summary>
        /// 超期时间
        /// </summary>
        /// <param name="now"></param>
        /// <returns></returns>
        public TimeSpan OutOfDate(DateTime now) => State != LendState.Return ? ShouldReturnTime - now : TimeSpan.Zero;

        /// <summary>
        /// 续借次数
        /// </summary>
        public int RenewalCount { get; private set; }

        /// <summary>
        /// 借阅状态
        /// </summary>
        public LendState State { get; private set; }

        /// <summary>
        /// 记录
        /// </summary>
        public ICollection<LendLog> Logs {get; private set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; private set; }

        public Lend(
            long bookId,
            [NotNull] string bookName,
            int quantity,
            DateTime lendTime,
            DateTime shouldReturnTime,
            LendState state = LendState.Lend,
            string remark = null)
        {
            BookId = bookId;
            BookName = bookName;
            Quantity = quantity;
            LendTime = lendTime;
            ShouldReturnTime = shouldReturnTime;
            State = state;
            Remark = remark;
            Logs = new List<LendLog>();
        }

        public Lend SetRemark([NotNull]string remark)
        {
            Remark = remark;
            return this;
        }

    }
}
