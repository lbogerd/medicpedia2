using MedicPedia2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicPedia2.Repositories.ArticleRepository
{
    public class SqlArticleRepository : IArticleRepository
    {
        private MedicContext dbContext = new MedicContext();

        public int Count => dbContext.Articles.Count();

        public void Add(Article article)
        {
            dbContext.Articles.Add(article);
            dbContext.SaveChanges();
        }

        public Article Get(Guid id) => dbContext.Articles.Find(id);

        public List<Article> GetArticleList() => dbContext.Articles.ToList();

        public void Update(Article article)
        {
            var dbArticle = Get(article.Id);

            dbArticle.Author = article.Author;
            dbArticle.Categories = article.Categories;
            dbArticle.Content = article.Content;
            dbArticle.LastChangedOn = DateTime.Now;
            dbArticle.Title = article.Title;
            dbArticle.Content = article.Content;
            dbArticle.Version = dbArticle.Version + 1;

            dbContext.SaveChanges();
        }
    }
}