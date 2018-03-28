namespace MedicPedia2.Migrations
{
    using MedicPedia2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MedicPedia2.Models.MedicContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.MedicContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var author = new Author
            {
                FirstName = "Semih",
                LastName = "Simsek"
            };

            context.Authors.Add(author);
            context.SaveChanges();

            var category1 = new Category
            {
                Name = "First category",
                Description = "A beautiful description about amazing stuff",
                SortIndex = 1,
                SortOrder = SortOrder.Logical
            };
            var category2 = new Category
            {
                Name = "Second category",
                Description = "The second main level category",
                SortIndex = 2,
                SortOrder = SortOrder.Logical
            };
            context.Categories.AddRange(new List<Category> {
                category1,
                category2
            });
            context.SaveChanges();


            var subCategory1 = new Category
            {
                Name = "First subcategory",
                Description = string.Empty,
                ParentCategory = category1,
                SortIndex = 1,
                SortOrder = SortOrder.Logical
            };
            var subCategory2 = new Category
            {
                Name = "Second subcategory",
                Description = string.Empty,
                ParentCategory = category1,
                SortIndex = 2,
                SortOrder = SortOrder.Logical
            };
            context.Categories.AddRange(new List<Category> {
                subCategory1,
                subCategory2 });
            context.SaveChanges();
            
            var subSubCategory1 = new Category
            {
                Name = "zzzFirst subsubcategory",
                Description = string.Empty,
                ParentCategory = subCategory1,
                SortIndex = 5,
                SortOrder = SortOrder.AlphabeticalAscending
            };
            var subSubCategory2 = new Category
            {
                Name = "aaaSecond subsubcategory",
                Description = string.Empty,
                ParentCategory = subCategory1,
                SortIndex = 1,
                SortOrder = SortOrder.AlphabeticalAscending
            };
            context.Categories.AddRange(new List<Category> {
                subSubCategory1,
                subSubCategory2 });
            context.SaveChanges();
            
            var categoryList = new List<Category>()
            {
                category1,
                subCategory1,
                subCategory2,
                subSubCategory1
            };

            var tag1 = new Tag
            {
                Name = "FirstTag"
            };
            var tag2 = new Tag
            {
                Name = "SecondTag"
            };
            var tag3 = new Tag
            {
                Name = "ThirdTag"
            };
            context.Tags.AddOrUpdate(tag1, tag2, tag3);
            context.SaveChanges();
        }
    }
}
