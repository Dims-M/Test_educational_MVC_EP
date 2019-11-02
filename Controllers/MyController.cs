using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Test_educational_MVC_EP.Controllers
{
    public class MyController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            //получаем ip клиента. Который защел по этой ссылке
            string ip = requestContext.HttpContext.Request.UserHostAddress;
            var response = requestContext.HttpContext.Response;
            response.Write("<h3>Ваш IP адрес: "+ip+" За вами выехали<h3>"); //Ответ отправляем клиенту
        }
    }
}