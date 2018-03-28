using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicPedia2.Models.ViewModels
{
    public class ArticleViewModel
    {
        public Article Article { get; set; }
        public List<Category> AllPossibleCategories { get; set; }
    }
}