using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicPedia2.Models;
using MedicPedia2.Repositories.ArticleRepository;
using MedicPedia2.Repositories.AuthorRepository;

namespace MedicPedia2.Controllers
{
    public class AuthorController : Controller
    {
        private SqlAuthorRepository AuthorRepo = new SqlAuthorRepository();

        [HttpGet]
        public ActionResult Index() => View(AuthorRepo.GetAll());

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(Author author)
        {
            AuthorRepo.Add(author);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(Guid id) => View(AuthorRepo.Get(id));

        [HttpPost]
        public ActionResult Update(Author author)
        {
            AuthorRepo.Update(author);
            return RedirectToAction("Index");
        }
    }
}