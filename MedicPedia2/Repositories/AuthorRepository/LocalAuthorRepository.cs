using MedicPedia2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicPedia2.Repositories.AuthorRepository
{
    public class LocalAuthorRepository : IAuthorRepository
    {
        private static LocalAuthorRepository defaultInstance;
        private List<Author> authors = new List<Author>();

        // fill with dummy data
        private LocalAuthorRepository()
        {
            authors.Add(new Author
            {
                Id = Guid.NewGuid(),
                FirstName = "EersteVoornaam",
                LastName = "EersteAchternaam"
            });
            authors.Add(new Author
            {
                Id = Guid.NewGuid(),
                FirstName = "TweedeVoornaam",
                LastName = "TweedeAchternaam"
            });
        }

        // enforce only having a single repo open
        public static LocalAuthorRepository DefaultInstance
            => defaultInstance ?? (defaultInstance = new LocalAuthorRepository());

        public List<Author> GetAll() => authors;

        public Author Get(Guid id) => authors.SingleOrDefault(p => p.Id == id);

        public void Add(Author author) => authors.Add(author);

        /// <summary>
        /// Finds the next logical ID to use.
        /// </summary>
        /// <returns>(Previous highest ID) + 1</returns>
        // because we do not use an actual database (yet) there's 
        // no auto increment on ID
        //public int GetNextId() => authors
        //    .OrderByDescending(p => p.Id)
        //    .FirstOrDefault().Id + 1;

        // basic update functionality
        public void Update(Author author)
        {
            var currentAuthor = authors.SingleOrDefault(p => p.Id == author.Id);
            if (currentAuthor != null)
            {
                currentAuthor.FirstName = author.FirstName;
                currentAuthor.LastName = author.LastName;
            }
        }
    }
}