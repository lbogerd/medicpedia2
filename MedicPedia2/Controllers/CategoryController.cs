using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicPedia2.Controllers
{
    public class CategoryController : Controller
    {
        SqlCategoryRepository CatRepo = new SqlCategoryRepository();

        [HttpGet]
        public ActionResult Index()
        {
            return View(CatRepo.GetMainCategories());
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            CatRepo.Add(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create(Guid? parentId)
        {
            var newCat = new Category() { Id = Guid.NewGuid() };
            return View(newCat);
        }

        [HttpPost]
        public ActionResult Delete(Guid categoryIdToDelete)
        {
            CatRepo.Remove(categoryIdToDelete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(Guid categoryIdToUpdate)
        {
            var toUpdate = CatRepo.Get(categoryIdToUpdate);
            return View(toUpdate);
        }

        [HttpPost]
        public ActionResult Update(Category category)
        {
            CatRepo.Update(category);

            return RedirectToAction("Index");
        }
    }
}