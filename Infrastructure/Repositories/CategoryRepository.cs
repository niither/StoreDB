using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.Infrastructure.Repositories
{
    public class CategoryRepository
    {
        private AppDbContext context;

        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateCategory(Category category)
        {
            context.Categories?.Add(category);
            context.SaveChanges();
        }

        public void UpdateCategory(int id, Category updatedCategory)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                category.Name = updatedCategory.Name;
                category.Description = updatedCategory.Description;
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            var category = context.Categories?.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                context.Categories?.Remove(category);
                context.SaveChanges();
            }
        }

        public Category? GetCategoryById(int id)
        {
            var category = context.Categories?.FirstOrDefault(c => c.Id == id);
            return category;
        }

        public List<Category> GetAllCategories()
        {
            return context.Categories?.ToList() ?? new List<Category>();
        }
    }
}