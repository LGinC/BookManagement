using System;

namespace BookManagement.Events
{
    [Serializable]
    public class BookCategoryNameChangedEto
    {
        /// <summary>
        /// 分类id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 分类名
        /// </summary>
        public string Name { get; set; }
    }
}
