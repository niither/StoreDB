using Microsoft.EntityFrameworkCore;
using StoreDB.Infrastructure;

namespace StoreDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbContext();
            context.Database.Migrate();
        }
    }
}
