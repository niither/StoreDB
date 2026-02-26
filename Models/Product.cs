using System;
using System.Collections.Generic;

namespace StoreDB.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public double Price { get; set; }

    public double Quantity { get; set; }

    public DateOnly? DateOfExpire { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Category> IdCategories { get; set; } = new List<Category>();
}
