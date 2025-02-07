using GanamukkulaTicketSales.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GanamukkulaTicketSales.Controllers
{
    public class HomeController : Controller
    {
        /*
         * Created by Ganamukkula
         * 6666666666666666666666666
         */
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
