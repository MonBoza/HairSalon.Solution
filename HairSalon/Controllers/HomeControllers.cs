using Microsoft.AspNetCore.Mvc;
// change the namespace to match the name of your project
namespace HairSalon.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}