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
        //*************

        [HttpGet] //получаем форму для добавления новой книги.
        public ActionResult Create()
        {
            return View(); //отправляем в браузер форму(представлене)
        }

        [HttpPost] //отправляем готовую форму с данными новой книги.
        public ActionResult Create(Book book)
        {
            bd.Books.Add(book); //записываев в БД новую книгу
            bd.SaveChanges();
            return RedirectToAction("Index"); //переодрисация на главную страницу
        }
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

            return View(bd.Books.ToList());
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
        ///Home/GetBook
        /// <summary>
        /// Работа с БД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
       
        //public ActionResult GetBook()
        //{

        //    return View();
        //}

        // Home/GetBook/
      
        public ActionResult GetBook(int id)
        {
            Book b = bd.Books.Find(id);

            if (b== null)
            {
                return HttpNotFound(); // возращаем ошибку
            }
            ViewBag.Temp = "Ваш поисковый результат \n";
            return View(b);
        }

        /// <summary>
        /// "Экшен(метод) для удаления ненужной страници(записи в БД)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public ActionResult Delete(int id)
        //{
        //    //модель
        //    Book b = bd.Books.Find(id);

        //    if (b != null)
        //    {
        //        bd.Books.Remove(b); // удаляем строку из бд
        //        bd.SaveChanges();

        //    }

        //    return RedirectToAction("Index"); //после удаления перенаправляем на главное окно.
        //}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            //модель
            Book b = bd.Books.Find(id);

            if (b != null)
            {

                return HttpNotFound();
            }
            return View();
        }


        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //модель
            Book b = bd.Books.Find(id);

            if (b != null)
            {

                return HttpNotFound();
            }

            bd.Books.Remove(b); // удаляем строку из бд
            bd.SaveChanges();
            return RedirectToAction("Index"); //после удаления перенаправляем на главное окно.
        }

        protected override void Dispose(bool disposing)
        {
            bd.Dispose();
            base.Dispose(disposing);
        }

    }
}