using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using SHOPPP_Cherkashneva.Data.Interfaces;
using SHOPPP_Cherkashneva.Data.Models;
using SHOPPP_Cherkashneva.Data.ViewModell;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace SHOPPP_Cherkashneva.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategorys IAllCategorys;
        private VMItems VMItems = new VMItems();
        private readonly IHostingEnvironment hostingEnvironment;

        public ItemsController(IItems IAllItems, ICategorys IAllCategorys, IHostingEnvironment hostingEnvironment)
        {
            this.IAllItems = IAllItems;
            this.IAllCategorys = IAllCategorys;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ViewResult List(int id = 0)
        {
            ViewBag.Title = "Страница с предметами";

            VMItems.Items = IAllItems.AllItems;
            VMItems.Categorys = IAllCategorys.AllCategorys;
            VMItems.SelectCategory = id;

            return View(VMItems);
        }
        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Categorys> Categorys = IAllCategorys.AllCategorys;
            return View(Categorys);
        }
        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile file, float price, int idCategory)
        {
            if(file != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, file.FileName);
                file.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            Items newItems = new Items()
            {
                Name = name,
                Description = description,
                Img = file.FileName,
                Price = (int)price,
                Category = new Categorys() { Id = idCategory }
            };
            int id = IAllItems.Add(newItems);
            return Redirect("/Items/Update?id=" + id);
        }
    }
}
