using MedicPedia2.Models;
using MedicPedia2.Models.ViewModels;
using MedicPedia2.Repositories.ArticleRepository;
using MedicPedia2.Repositories.AuthorRepository;
using MedicPedia2.Repositories.CategoryRepository;
using System;
using System.Web.Mvc;

namespace MedicPedia2.Controllers
{
    public class ArticleController : Controller
    {
        SqlArticleRepository articleRepository = new SqlArticleRepository();
        SqlAuthorRepository authorRepository = new SqlAuthorRepository();
        SqlCategoryRepository categoryRepository = new SqlCategoryRepository();

        // GET: Article
        public ActionResult Index()
        {
            var articleList = articleRepository.GetArticleList();
            return View(articleList);
        }

        public ActionResult Article(Guid id)
        {
            var articleVm = new ArticleViewModel();
            articleVm.CreateSelectedList(authorRepository);
            return View(articleVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var articleVm = new ArticleViewModel();
            articleVm.CreateSelectedList(authorRepository);
            return View(articleVm);
        }

        [HttpPost]
        public ActionResult Create(Article article)
        {
            articleRepository.Add(article);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(Guid articleId)
        {
            var articleToUpdate = articleRepository.Get(articleId);
            return View(articleToUpdate);
        }

        [HttpPost]
        public ActionResult Update(Article article)
        {
            articleRepository.Update(article);

            return RedirectToAction("Article");
        }

    }
}