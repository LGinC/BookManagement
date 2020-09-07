using System;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Events
{
    [Serializable]
    public class BookCategoryCountChangedEto
    {
        /// <summary>
        /// 分类id
        /// </summary>
        public long Id { get;  set; }

        /// <summary>
        /// 变更数量
        /// </summary>
        [Range(0, int.MaxValue)]
        public int Count { get; set; }

        /// <summary>
        /// 是否为增加
        /// </summary>
        public bool IsAdd { get; set; } = true;
    }
}
