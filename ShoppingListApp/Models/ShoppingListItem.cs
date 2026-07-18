using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListApp.Models;

public class ShoppingListItem
{
    public int Id { get; set; }
    public int shoppingListId { get; set; }
    public ShoppingList? ShoppingList { get; set; }
    public int productId { get; set; }
    public Product? Product { get; set; }
    public int quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal price { get; set; }
    public bool isPurchased { get; set; }
    public string? notes { get; set; }
}
