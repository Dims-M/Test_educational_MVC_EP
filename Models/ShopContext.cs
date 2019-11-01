using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test_educational_MVC_EP.Models
{
    public class ShopContext: DbContext
    {
        /// <summary>
        /// Свойство подключения к таблице отвечающий за хранения товара
        /// </summary>
        public DbSet<Car> Cars { get; set; }
        /// <summary>
    }
}