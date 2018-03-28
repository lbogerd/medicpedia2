using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicPedia2.Models
{
    public class Article
    {
        public Guid Id { get; set; }
        public Author Author { get; set; }
        public DateTime PublishedOn { get; set; }
        public DateTime LastChangedOn { get; set; }
        public int Version { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Categories { get; set; }
    }
}