using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedicPedia2.Models
{
    public class Article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime PublishedOn { get; set; }
        public DateTime? LastChangedOn { get; set; }
        public int Version { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual Author Author { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}