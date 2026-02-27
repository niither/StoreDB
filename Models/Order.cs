using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDB.Models;

public partial class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime DateOfOrder { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be >= 0")]
    public int Quantity { get; set; }

    [Required]
    public int UserId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
