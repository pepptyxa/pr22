using Microsoft.AspNetCore.Mvc;
using SHOPPP_Cherkashneva.Data.Interfaces;

namespace SHOPPP_Cherkashneva.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategorys IAllCategories;

        public ItemsController(IItems IAllItems, ICategorys IAllCategories)
        {
            this.IAllItems = IAllItems;
            this.IAllCategories = IAllCategories;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Страница с предметами";

            var items = IAllItems.AllItems;
            return View(items);
        }
    }
}
