using MedicPedia2.Models;
using MedicPedia2.Models.ViewModels;
using MedicPedia2.Repositories.ArticleRepository;
using MedicPedia2.Repositories.AuthorRepository;
using MedicPedia2.Repositories.CategoryRepository;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MedicPedia2.Controllers
{
    public class ArticleController : Controller
    {
        SqlArticleRepository articleRepository = new SqlArticleRepository();
        SqlAuthorRepository authorRepository = new SqlAuthorRepository();
        SqlCategoryRepository categoryRepository = new SqlCategoryRepository();

        public ActionResult Index()
        {
            var articleList = articleRepository.GetArticleList();
            return View(articleList);
        }

        public ActionResult Article(Guid id)
        {
            var articleVm = new ArticleViewModel(articleRepository, id);
            return View(articleVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var articleVm = new ArticleViewModel(authorRepository, categoryRepository);
            return View(articleVm);
        }

        [HttpPost]
        public ActionResult Create(ArticleViewModel articleVm)
        {
            articleRepository.Add(articleVm.Article);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(Guid articleId)
        {
            var articleVm = new ArticleViewModel( articleRepository, authorRepository,categoryRepository, articleId);
            return View(articleVm);
        }

        [HttpPost]
        public ActionResult Update(ArticleViewModel article)
        {
            articleRepository.Update(article.Article);
            return RedirectToAction("Article");
        }

    }
}