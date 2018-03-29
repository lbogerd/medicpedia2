using MedicPedia2.Repositories.ArticleRepository;
using MedicPedia2.Repositories.AuthorRepository;
using MedicPedia2.Repositories.CategoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicPedia2.Models.ViewModels
{
    public class ArticleViewModel
    {

        
        public Article Article { get; set; }
        public List<SelectListItem> AllPossibleCategories { get; set; }
        public List<SelectListItem> AllPossibleAuthors { get; set; }

        public ArticleViewModel()
        {


        }

        public ArticleViewModel(SqlArticleRepository articleRepository, SqlAuthorRepository authorRepository, SqlCategoryRepository categoryRepository, Guid id)
        {
            this.Article = articleRepository.Get(id);
            CreateCategoryList(categoryRepository);
            CreateAuthorList(authorRepository);
        
            
        }

        private void CreateAuthorList(SqlAuthorRepository authorRepository)
        {
            this.AllPossibleAuthors = new List<SelectListItem>();

            foreach (var author in authorRepository.GetAll())
            {
                AllPossibleAuthors.Add(new SelectListItem { Text = author.FirstName + " " + author.LastName, Value = author.FirstName});
            }
        }

        private void CreateCategoryList(SqlCategoryRepository categoryRepository)
        {
            this.AllPossibleCategories = new List<SelectListItem>();

            foreach (var category in categoryRepository.GetAllCategories())
            {
                AllPossibleCategories.Add(new SelectListItem { Text = category.Name, Value = category.Id.ToString()});
            }
        }


    }

   


}