using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDB.Models;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "User name can not be longer than 50 symbols")]
    public string Name { get; set; } = null!;

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(100, ErrorMessage = "Password can not be longer than 100 symbols")]
    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
