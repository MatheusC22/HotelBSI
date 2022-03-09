using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace HotelApp.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Welcome(string name, int ID = 1) {
            return HtmlEncoder.Default.Encode($"Bem vindo ${name}");
        }
    }
}