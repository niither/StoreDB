using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.Infrastructure.Repositories
{
    public class OrderRepository
    {
        private AppDbContext context;

        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateOrder(Order order)
        {
            context.Orders?.Add(order);
            context.SaveChanges();
        }

        public void UpdateOrder(int id, Order updatedOrder)
        {
            var order = context.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                order.UserId = updatedOrder.UserId;
                order.ProductId = updatedOrder.ProductId;
                order.Quantity = updatedOrder.Quantity;
                context.SaveChanges();
            }
        }

        public void DeleteOrder(int id)
        {
            var order = context.Orders?.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                context.Orders?.Remove(order);
                context.SaveChanges();
            }
        }

        public Order? GetOrderById(int id)
        {
            var order = context.Orders?.FirstOrDefault(o => o.Id == id);
            return order;
        }

        public List<Order> GetAllOrders()
        {
            return context.Orders?.ToList() ?? new List<Order>();
        }
    }
}