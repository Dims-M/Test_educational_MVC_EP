using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_educational_MVC_EP.Models;

//https://www.youtube.com/watch?v=F7rhqyphToQ&list=PLL-k0Ff5RfqXnwdDG61WqZ2j3KXUPnfmq&index=9&t=510s
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
        [HttpGet]
        public ActionResult Buy(int? id)
        {
            ViewBag.BookId = id; //
            return View();
        }

        /// <summary>
        /// Метод Byu покупки с заполненым параметром
        /// </summary>
        /// <param name="purchase">заполненый параметр из вьюхи Buy. Где вводим данне при заказе.</param>
        /// <returns></returns>
        [HttpPost] //срабатывает когда мы отправляем запрос к серверу
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            //Добавляем в БД инфу о покупке
            bd.Purchases.Add(purchase);

            bd.SaveChanges();

            return $"Cпасибо {purchase.Person}, за заказ нашей книги";
        }

        //тестовой метод гет id


        public ActionResult About()
        {
            var cars = bd2.Cars; // присвоеваем подключение контроллеру
            ViewBag.Cars = cars;
            ViewBag.Message = "Страница описания вашего приложения.";

            return View("Contact");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Наши контакты.";

            return View();
        }


        //Тестрой метод дя переадрисации
        public ActionResult GetVoid(int id = 1)
        {
            if (id > 2)
            {
                return Redirect("/Home/Contact");
                // return Redirect("/Home/Plug");
            }
            else
            {
                // return Redirect("/Home/Index");
                //https://www.youtube.com/watch?v=PYpnT_7hKP0&list=PLL-k0Ff5RfqXnwdDG61WqZ2j3KXUPnfmq&index=24
                return View("/Home/Plug");
            }

        }


        public ActionResult GetDateDB(int id = 1)
        {

            return View("/Home/Plug");
        }


    }
}