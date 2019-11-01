using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_educational_MVC_EP.Models;

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