using MedicPedia2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicPedia2.Repositories.ArticleRepository
{
    public class LocalArticleRepository : IArticleRepository
    {
        private static LocalArticleRepository defaultInstance;
        public List<Article> articles;

        public static LocalArticleRepository DefaultInstance
        {
            get
            {
                // return defaultInstance ?? (defaultInstance = new CategoryRepository());

                if (defaultInstance == null)
                {
                    defaultInstance = new LocalArticleRepository();
                }

                return defaultInstance;
            }
        }

        private Article FindArticle(IEnumerable<Article> list, Guid? id)
        {
            foreach (var article in list)
            {
                if (article.Id == id)
                {
                    return article;
                }
            }

            return null;
        }

        public Article Get(Guid? id)
        {
            return this.FindArticle(this.articles, id);
        }

        public void Update(Article article)
        {
            if (article?.Id == null)
            {
                return;
            }

            var articleInList = this.Get(article.Id);

            if (articleInList == null)
            {
                return;
            }

            articleInList.Title = article.Title;
            articleInList.Author = article.Author;
            //articleInList.Tags = article.Tags;
            articleInList.Content = article.Content;
        }

        public int Count
        {
            get { return this.articles.Count; }
        }

        public LocalArticleRepository()
        {
            this.articles = new List<Article>();
            this.CreateDummyDataArticle();
        }


        public void Add(Article article)
        {
            if (article.Id == null
                || article.Id == Guid.Empty)
            {
                article.Id = Guid.NewGuid();
            }

            articles.Add(article);
        }

        public List<Article> GetArticleList()
        {
            return this.articles.ToList();
        }

        public Article Get(Guid id)
        {
            return articles.SingleOrDefault(p => p.Id == id);
        }

        private void CreateDummyDataArticle()
        {
            var sa = new Author { Id = Guid.NewGuid(), FirstName = "Semih", LastName = "Simsek" };
            var article1 = new Article { Id = Guid.NewGuid(), Author = sa, Content = "This is a medical article about some illness This is a medical article about some illness", Title = "This is a article title" };
            var article2 = new Article { Id = Guid.NewGuid(), Author = sa, Content = "blabla", Title = "Title" };
            var article3 = new Article { Id = Guid.NewGuid(), Author = sa, Content = "blabla", Title = "Title" };

            articles.Add(article1);
            articles.Add(article2);
            articles.Add(article3);

        }
    }
}