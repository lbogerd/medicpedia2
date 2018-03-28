using System;
using System.Collections.Generic;
using System.Text;

namespace Medicpedia.Data.Classes
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentCategory { get; set; }
        public SortOrder SortOrder { get; set; }
        public List<Category> ChildrenCategory { get; set; }
        public int SortIndex { get; set; }

        public Category()
        {
            ChildrenCategory = new List<Category>();
        }
    }
}
