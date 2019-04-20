using System.Web.Mvc;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Index()
        {
            var person = new PersonModels("12/14/1991");
            return View(person);
        }
    }
}