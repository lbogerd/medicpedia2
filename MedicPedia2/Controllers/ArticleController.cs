using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicPedia2.Models;
using MedicPedia2.Repositories.ArticleRepository;
using MedicPedia2.Repositories.CategoryRepository;

namespace MedicPedia2.Controllers
{
    public class ArticleController : Controller
    {

        Article SingleArticle;
        SqlArticleRepository articleRepository = new SqlArticleRepository();
        SqlCategoryRepository categoryRepository = new SqlCategoryRepository();

        // GET: Article
        public ActionResult Index()
        {
            var articleList = articleRepository.GetArticleList();
            return View(articleList);
        }

        public ActionResult Article(Guid id)
        {
            var articleList = articleRepository.GetArticleList();

            for (int i = 0; i < articleList.Count; i++)
            {
                if (articleList[i].Id == id)
                { this.SingleArticle = articleList[i]; }
            }

            return View(SingleArticle);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Article article = new Article();
            return View(article);
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