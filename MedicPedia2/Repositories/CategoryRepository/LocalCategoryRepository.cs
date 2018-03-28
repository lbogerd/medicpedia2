using MedicPedia2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicPedia2.Repositories.CategoryRepository
{
    public class LocalCategoryRepository : ICategoryRepository
    {
        private static LocalCategoryRepository defaultInstance;
        private List<Category> categories;

        public static LocalCategoryRepository DefaultInstance
        {
            get
            {
                // return defaultInstance ?? (defaultInstance = new CategoryRepository());

                if (defaultInstance == null)
                {
                    defaultInstance = new LocalCategoryRepository();
                }

                return defaultInstance;
            }
        }

        public int Count
        {
            get { return this.categories.Count; }
        }

        public LocalCategoryRepository()
        {
            this.categories = new List<Category>();
            this.CreateDummyCategories();
        }

        public void Add(Category category)
        {
            if (category.Id == null
                || category.Id == Guid.Empty)
            {
                category.Id = Guid.NewGuid();
            }

            //if (category.ParentCategory == null)
            //{
            // Add category on top level (no parent).
            this.categories.Add(category);
            //}
            //else
            //{
            // Add category as child of parent category.
            //var parent = this.Get(category.ParentCategoryId);
            //parent.ChildrenCategoryId.Add(category);
            //}
        }

        public List<Category> GetAllCategories(List<Category> categories = null)
        {
            var result = new List<Category>();

            (categories ?? this.GetMainCategories()).ForEach(category =>
            {
                result.Add(category);
                //result.AddRange(this.GetAllCategories(category.ChildrenCategory));
            });

            return result;
        }

        public Category Get(Guid id)
        {
            return this.FindCategory(this.categories, id);
        }

        public List<Category> GetMainCategories()
        {
            return this.categories.Where(c => c.ParentCategory == null)
                .ToList();
        }

        public void Remove(Guid id)
        {
            // Find category we want to remove.
            var remove = this.FindCategory(this.categories, id);

            if (remove == null)
            {
                return;
            }

            if (remove.ParentCategory == null)
            {
                // Category has no parent so it's in the main (this.categories) list.
                // Remove it from the list.
                this.categories.RemoveAll(c => c.Id == id);
            }
            else
            {
                // Category has a parent so it's in the Children list of the parent category.
                // Remove it from the Children list.
                throw new NotImplementedException();
            
            //var parent = this.FindCategory(this.categories, remove.ParentCategory);
                //parent.ParentCategoryId.RemoveAll(c => c.Id == id);
            }
        }

        /// <summary>
        /// Finds a category with specified identifier on any level in the hierarchy.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private Category FindCategory(IEnumerable<Category> list, Guid id)
        {
            foreach (var category in list)
            {
                if (category.Id == id)
                {
                    return category;
                }

                //var foundInChildren = this.FindCategory(category.ChildrenCategory, id);

                //if (foundInChildren != null)
                //{
                //    return foundInChildren;
                //}
            }

            return null;
        }

        public void Update(Category category)
        {
            if (category?.Id == null)
            {
                return;
            }

            var categoryInList = this.Get(category.Id);

            if (categoryInList == null)
            {
                return;
            }

            categoryInList.Name = category.Name;
            categoryInList.SortIndex = category.SortIndex;
            categoryInList.SortOrder = category.SortOrder;
        }

        /// <summary>
        /// Fills the repository with dummy data (i.e. stubs)
        /// </summary>
        private void CreateDummyCategories()
        {
            //var category1 = new Category { Id = Guid.NewGuid(), Name = "Aandoeningen", SortOrder = SortOrder.AlphabeticalAscending };

            //var subcategory1 = new Category { Id = Guid.NewGuid(), Name = "Viraal", ParentCategory = category1.Id };

            //var subsubcategory1 = new Category { Id = Guid.NewGuid(), Name = "Griep", ParentCategory = subcategory1.Id };
            //var subsubcategory2 = new Category { Id = Guid.NewGuid(), Name = "Verkoudheid", ParentCategory = subcategory1.Id };
            //var subsubcategory3 = new Category { Id = Guid.NewGuid(), Name = "HIV", ParentCategory = subcategory1.Id };

            //var subcategory2 = new Category { Id = Guid.NewGuid(), Name = "Bacteriaal", ParentCategory = category1.Id };

            //var subsubcategory4 = new Category { Id = Guid.NewGuid(), Name = "Tetanus", ParentCategory = subcategory2.Id };
            //var subsubcategory5 = new Category { Id = Guid.NewGuid(), Name = "Schurft", ParentCategory = subcategory2.Id };

            //var category2 = new Category { Id = Guid.NewGuid(), Name = "Onderzoeken", SortOrder = SortOrder.AlphabeticalAscending };

            //var subcategory3 = new Category { Id = Guid.NewGuid(), Name = "Universitair", ParentCategory = category2.Id };

            //category1.ChildrenCategory.Add(subcategory1);
            //category1.ChildrenCategory.Add(subcategory2);
            //category2.ChildrenCategory.Add(subcategory3);

            //subcategory1.ChildrenCategory.Add(subsubcategory1);
            //subcategory1.ChildrenCategory.Add(subsubcategory2);
            //subcategory1.ChildrenCategory.Add(subsubcategory3);

            //subcategory2.ChildrenCategory.Add(subsubcategory4);
            //subcategory2.ChildrenCategory.Add(subsubcategory5);

            //this.Add(category1);
            //this.Add(category2);
        }
    }
}