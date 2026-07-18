using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListApp.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;
    [StringLength(500)]
    public string? Description { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal defaultPrice { get; set; }
    public string? imageUrl { get; set; } 
    public int categoryId { get; set; }
    public Category? Category { get; set; }
    public ICollection<ShoppingListItem> ShoppingListItems { get; set; } = new List<ShoppingListItem>();
}
