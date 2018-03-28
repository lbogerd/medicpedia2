using MedicPedia2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicPedia2.Repositories.AuthorRepository
{
    public interface IAuthorRepository
    {
        void Add(Author author);
        Author Get(Guid id);
        List<Author> GetAll();
        void Update(Author author);
    }
}