using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using SHOPPP_Cherkashneva.Data.Interfaces;
using SHOPPP_Cherkashneva.Data.Models;
using SHOPPP_Cherkashneva.Data.ViewModell;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System;

namespace SHOPPP_Cherkashneva.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategorys IAllCategorys;
        private VMItems VMItems = new VMItems();
        private readonly IHostingEnvironment hostingEnviroment;

        public ItemsController(IItems IAllItems, ICategorys IAllCategorys, IHostingEnvironment hostingEnviroment)
        {
            this.IAllItems = IAllItems;
            this.IAllCategorys = IAllCategorys;
            this.hostingEnviroment = hostingEnviroment;
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
                var uploads = Path.Combine(hostingEnviroment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, file.FileName);
                file.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            Items newItems = new Items()
            {
                Name = name,
                Description = description,
                Img = "/img/" + Path.GetFileName(file.FileName),
                Price = (int)price,
                Category = new Categorys() { Id = idCategory }
            };
            int id = IAllItems.Add(newItems);
            return Redirect("/Items/Update?id=" + id);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = IAllItems.AllItems.FirstOrDefault(x => x.Id == id);
            ViewBag.Categories = IAllCategorys.AllCategorys;
            return View(item);
        }

        [HttpPost]
        public IActionResult Update(int id, string name, string description, IFormFile file, float price, int idCategory)
        {
            var existingItem = IAllItems.AllItems.FirstOrDefault(x => x.Id == id);
            if (existingItem == null) return NotFound();

            if (file != null && file.Length > 0)
            {
                var uploads = Path.Combine(hostingEnviroment.WebRootPath, "img");
                Directory.CreateDirectory(uploads);
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(uploads, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                existingItem.Img = "/img/" + fileName;
            }

            existingItem.Name = name;
            existingItem.Description = description;
            existingItem.Price = Convert.ToInt32(price);
            existingItem.Category = new Categorys() { Id = idCategory };

            IAllItems.Update(existingItem);

            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            IAllItems.Delete(id);
            return RedirectToAction("List");
        }

        public ActionResult Basket(int idItem = -1)
        {
            if (idItem != -1)
            {
                Startup.BasketItem.Add(new ItemsBasket(1, IAllItems.AllItems.Where(x => x.Id == idItem).First()));
            }
            return Json(Startup.BasketItem);
        }
        
    }
}
