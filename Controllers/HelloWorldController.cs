using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace HotelApp.Controllers
{
    public class HelloWorldController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string nome, int numTimes = 1)
        {
            ViewData["mensagem"] = "Olá " + nome;
            ViewData["vezes"] = numTimes;

            return View();
        }
    }
}