using MedicPedia2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicPedia2.Repositories.ArticleRepository
{
    public interface IArticleRepository
    {
        int Count { get; }

        void Add(Article article);
        Article Get(Guid id);
        List<Article> GetArticleList();
        void Update(Article article);
    }
}