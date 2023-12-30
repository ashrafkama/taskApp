using Microsoft.AspNetCore.Mvc;

namespace TaskAppClient.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            string a = "hi task";

            return View(a);
        }
    }
}
