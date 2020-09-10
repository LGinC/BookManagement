using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookManagement.Books
{
    /// <summary>
    /// 图书分类
    /// </summary>
    public class BookCategory : CreationAuditedAggregateRoot<long>
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 分类代码
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; private set; }

        /// <summary>
        /// 所在位置
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        /// 图书数量
        /// </summary>
        public long BookCount { get; private set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; private set; }

        public BookCategory([NotNull]string name, [NotNull] string code, string icon, string location, string description)
        {
            Name = name;
            Code = code;
            Icon = icon;
            Location = location;
            Description = description;
        }

        /// <summary>
        /// 增加图书数量
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public BookCategory AddCount(int count)
        {
            if (count <= 0)
                return this;

            BookCount += count;
            return this;
        }

        /// <summary>
        /// 减少图书数量
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public BookCategory SubtractCount(int count)
        {
            if (count <= 0)
                return this;
            BookCount -= count;
            return this;
        }
    }
}
