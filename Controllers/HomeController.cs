using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_educational_MVC_EP.Models;


//https://www.youtube.com/watch?v=o5o2jW-o5PY&list=PLL-k0Ff5RfqXnwdDG61WqZ2j3KXUPnfmq&index=6&t=230s
namespace Test_educational_MVC_EP.Controllers
{
    /// <summary>
    /// контроллеры отвечают за ссылочные запросы. Home. + методы
    /// </summary>
    public class HomeController : Controller
    {
        //Для ввывода данных из БД нужен контекст БД
        //
        BookContext bd = new BookContext();
        ShopContext bd2 = new ShopContext();
        public ActionResult Index()
        {
            var books = bd.Books; // присоединение к конкретной бд
           //  Обьект ViewBag может хранить в себе любые переменные
            ViewBag.Books = books;
            return View();

        }

        /// <summary>
        /// Покупка книги.
        /// </summary>
        /// <param name="id">Параметр ID нужной книги</param>
        /// <returns>возращает вьюху</returns>
        public ActionResult Buy(int? id)
        {
            ViewBag.BookId = id; //
            return View();
        }

        /// <summary>
        /// Метод Byu покупки с заполненым параметром
        /// </summary>
        /// <param name="purchase">заполненый параметр из вьюхи</param>
        /// <returns></returns>
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            //Добавляем в БД инфу о покупке
            bd.Purchases.Add(purchase);

            bd.SaveChanges();

           return $"Cпасибо {purchase.Person}, за покупку книги";
        }

        public ActionResult About()
        {
            var cars = bd2.Cars; // присвоеваем подключение контроллеру
            ViewBag.Cars = cars;
            ViewBag.Message = "Страница описания вашего приложения.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}