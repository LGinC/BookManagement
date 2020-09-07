using System;

namespace BookManagement.Books
{
    [Flags]
    public enum LendState
    {
        /// <summary>
        /// 预订
        /// </summary>
        PreOrder = 1,

        /// <summary>
        /// 借阅中
        /// </summary>
        Lend = 2,

        /// <summary>
        /// 已归还
        /// </summary>
        Return = 4,
    }
}
