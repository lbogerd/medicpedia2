using MedicPedia2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicPedia2.Repositories.AuthorRepository
{
    public class SqlAuthorRepository : IAuthorRepository
    {
        private MedicContext dbContext = new MedicContext();

        public void Add(Author author)
        {
            dbContext.Authors.Add(author);
            dbContext.SaveChanges();
        }

        public Author Get(Guid id) => dbContext.Authors.Find(id);

        public List<Author> GetAll() => dbContext.Authors.ToList();

        public void Update(Author author)
        {
            var dbAuthor = Get(author.Id);

            dbAuthor.FirstName = author.FirstName;
            dbAuthor.LastName = author.LastName;

            dbContext.SaveChanges();
        }
    }
}