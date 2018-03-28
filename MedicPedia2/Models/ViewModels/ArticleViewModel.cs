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
    }
}