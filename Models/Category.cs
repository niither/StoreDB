using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDB.Models;

public partial class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Category name can not be longer than 50 symbols")]
    public string Name { get; set; } = null!;

    [StringLength(200, ErrorMessage = "Category descr can not be longer than 200 symbols")]
    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
