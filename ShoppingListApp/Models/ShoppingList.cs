using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Models;

public class ShoppingList
{
    public int Id { get; set; }
    [Required]
    [StringLength(150)]
    public string Title { get; set; } = string.Empty;
    [StringLength(500)]
    public string? Description { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public string userId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }
    public ICollection<ShoppingListItem> Items { get; set; } = new List<ShoppingListItem>();
}
