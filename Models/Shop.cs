using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_educational_MVC_EP.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string nvarchar { get; set; }
        public int Price { get; set; }
        public int IsFavourite { get; set; }
        public int available { get; set; }
        public int CategoryId { get; set; }
    }
}