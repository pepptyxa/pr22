using Microsoft.AspNetCore.Mvc;

namespace SHOPPP_Cherkashneva.Controllers
{
    public class HomeController : Controller
    {
        public RedirectResult Index() {
            return Redirect("/Items/List");
        }
    }
}
