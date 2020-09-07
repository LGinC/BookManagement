using BookManagement.Events;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookManagement.Books
{
    public class Book : FullAuditedAggregateRoot<long>
    {
        public long CategoryId { get; private set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; private set; }

        /// <summary>
        /// 书名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 国际标准书号
        /// </summary>
        public string ISBN { get; private set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; private set; }

        /// <summary>
        /// 出版社
        /// </summary>
        public string Publisher { get; private set; }

        /// <summary>
        /// 封面
        /// </summary>
        public string Image { get; private set; }

        /// <summary>
        /// 语言
        /// </summary>
        public string Languge { get; private set; }

        /// <summary>
        /// 当前所有数量
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// 已借出数量
        /// </summary>
        public int LentCount { get; private set; }


        public Book(string name, string iSBN, string author, string publisher, string image, string languge, long categoryId, string categoryName, int quantity = 0)
        {
            Name = name;
            ISBN = iSBN;
            Author = author;
            Publisher = publisher;
            Image = image;
            Languge = languge;
            Quantity = quantity;
            CategoryId = categoryId;
            CategoryName = categoryName;

            if(quantity > 0)
            {
                AddLocalEvent(new BookCategoryCountChangedEto
                {
                    Id = CategoryId,
                    Count = Quantity,
                });
            }
        }

        /// <summary>
        /// 上架
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public Book PutOn(int quantity)
        {
            if(quantity <= 0)
            {
                return this;
            }
            Quantity += quantity;
            AddLocalEvent(new BookCategoryCountChangedEto
            {
                Id = CategoryId,
                Count = Quantity,
            });

            return this;
        }

        /// <summary>
        /// 下架
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public Book PullOff(int quantity)
        {
            if (quantity <= 0)
            {
                return this;
            }

            if(quantity >= Quantity)
            {
                Quantity = 0;
                AddLocalEvent(new BookCategoryCountChangedEto
                {
                    Id = CategoryId,
                    Count = Quantity,
                    IsAdd = false
                });
                return this;
            }

            Quantity -= quantity;
            AddLocalEvent(new BookCategoryCountChangedEto
            {
                Id = CategoryId,
                Count = quantity,
                IsAdd = false
            });
            return this;
        }

        /// <summary>
        /// 设置分类
        /// </summary>
        /// <param name="id">分类id</param>
        /// <param name="name">分类名称</param>
        /// <param name="triggerAddCategoryCount">是否触发增加分类图书数量事件</param>
        /// <returns></returns>
        internal Book SetCategory(long id,
                                  string name,
                                  bool triggerAddCategoryCount = true)
        {
            if (id != CategoryId && triggerAddCategoryCount)
            {
                
                AddLocalEvent(new BookCategoryCountChangedEto
                {
                    Id = id,
                    Count = Quantity,
                });

                AddLocalEvent(new BookCategoryCountChangedEto
                {
                    Id = CategoryId,
                    Count = Quantity,
                    IsAdd = false
                });
            }

            CategoryId = id;
            CategoryName = name;
            return this;
        }



    }
}
