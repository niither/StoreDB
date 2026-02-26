using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.Infrastructure.Repositories
{
    public class ProductRepository
    {
        private AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateProduct(Product product)
        {
            context.Products?.Add(product);
            context.SaveChanges();
        }

        public void UpdateProduct(int id, Product updatedProduct)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Description = updatedProduct.Description;
                product.Price = updatedProduct.Price;
                product.Quantity = updatedProduct.Quantity;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            var product = context.Products?.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                context.Products?.Remove(product);
                context.SaveChanges();
            }
        }

        public Product? GetProductById(int id)
        {
            var product = context.Products?.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return context.Products?.ToList() ?? new List<Product>();
        }
    }
}