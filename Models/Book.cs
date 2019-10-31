using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_educational_MVC_EP.Models
{
    //https://www.youtube.com/watch?v=GkJ3qBTniPM&list=PLL-k0Ff5RfqXnwdDG61WqZ2j3KXUPnfmq&index=4

    /// <summary>
    /// Класс описывает книгу (товар)
    /// </summary>
    public class Book
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Autor { get; set; }
        public int Price { get; set; }


    }
}