using MedicPedia2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicPedia2.Repositories.CategoryRepository
{
    public class SqlCategoryRepository : ICategoryRepository
    {
        private MedicContext dbContext = new MedicContext();

        public int Count => dbContext.Categories.Count();

        public void Add(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
        }

        public Category Get(Guid id) => dbContext.Categories.Find(id);

        public List<Category> GetAllCategories(List<Category> categories = null)
        {
            throw new NotImplementedException();
            //var result = new List<Category>();

            //(categories ?? GetMainCategories()).ForEach(category =>
            //{
            //    result.Add(category);
            //    result.AddRange(this.GetAllCategories(category.));
            //});

            //return result;
        }

        public List<Category> GetMainCategories() => dbContext.Categories.Where(p => p.ParentCategoryId == null).ToList();

        public void Remove(Guid id)
        {
            dbContext.Categories.Remove(Get(id));
            dbContext.SaveChanges();
        }

        public void Update(Category category)
        {
            var dbCategory = Get(category.Id);

            dbCategory.Name = category.Name;
            dbCategory.SortIndex = category.SortIndex;
            dbCategory.SortOrder = category.SortOrder;
            dbCategory.Description = category.Description;

            dbContext.SaveChanges();
        }
    }
}