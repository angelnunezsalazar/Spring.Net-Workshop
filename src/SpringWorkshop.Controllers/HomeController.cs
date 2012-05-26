using System;
using System.Web.Mvc;

namespace SpringWorkshop.Controllers
{
    public class HomeController:Controller
    {
        private readonly string saludo;

        public HomeController(string saludo)
        {
            this.saludo = saludo;
        }

        public String Index()
        {
            return saludo;
        }
    }
}
