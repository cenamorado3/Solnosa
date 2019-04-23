using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}