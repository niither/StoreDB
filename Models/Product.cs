using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDB.Models;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Product name can not be longer than 50 symbols")]
    public string Name { get; set; } = null!;

    [StringLength(200, ErrorMessage = "Product descr can not be longer than 200 symbols")]
    public string? Description { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be >= 0")]
    public double Price { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Quantity must be >= 0")]
    public double Quantity { get; set; }

    [Required]
    public DateOnly? DateOfExpire { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
