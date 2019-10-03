using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace ApiBookLibrary.Controllers
{
    [Route("[controller]")]
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            ViewBag.Teste = "Home Page";
            return View();
        }
        
    }
}