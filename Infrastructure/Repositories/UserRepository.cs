using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.Infrastructure.Repositories
{
    public class UserRepository
    {
        private AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateUser(User user)
        {
            context.Users?.Add(user);
            context.SaveChanges();
        }

        public void UpdateUser(int id, User updatedUser)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.Email = updatedUser.Email;
                user.Password = updatedUser.Password;
                context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            var user = context.Users?.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                context.Users?.Remove(user);
                context.SaveChanges();
            }
        }

        public User? GetUserById(int id)
        {
            var user = context.Users?.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public List<User> GetAllUsers()
        {
            return context.Users?.ToList() ?? new List<User>();
        }
    }
}