using MedicPedia2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicPedia2.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        int Count { get; }

        void Add(Category category);
        Category Get(Guid id);
        List<Category> GetAllCategories(List<Category> categories = null);
        List<Category> GetMainCategories();
        void Remove(Guid id);
        void Update(Category category);
    }
}