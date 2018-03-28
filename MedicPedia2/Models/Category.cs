using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicPedia2.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SortOrder SortOrder { get; set; }
        public int SortIndex { get; set; }

        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildrenCategories { get; set; }
    }
}
