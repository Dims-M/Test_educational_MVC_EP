using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test_educational_MVC_EP.Models
{
    /// <summary>
    /// Контекст данны. Связь с БД
    /// </summary>
    public class BookContext : DbContext
    {
        /// <summary>
        /// Свойство подключения к таблице отвечающий за хранения товара
        /// </summary>
        public DbSet<Book> Books { get; set; }
        /// <summary>
        /// Свойство подключения к таблице отвечающий за факт продажи
        /// </summary>
        public DbSet<Purchase> Purchases { get; set; }

    }

    /// <summary>
    /// Класс инициализатор. Будет пересоздовать новую дб. при запуске
    /// </summary>
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            //Добавляем новые строки в БД
            db.Books.Add(new Book { Name = "Война и Мир", Autor = "Л.Толстой", Price = 220 });
            db.Books.Add(new Book { Name = "ОТци и Дети", Autor = "И. Тургеньев", Price = 180 });
            db.Books.Add(new Book { Name = "Чайка", Autor = "А.Чехов", Price = 150 });
            base.Seed(db);
        }

    }
}