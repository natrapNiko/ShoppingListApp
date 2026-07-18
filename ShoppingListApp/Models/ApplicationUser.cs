using Microsoft.AspNetCore.Identity;

namespace ShoppingListApp.Models;
public class ApplicationUser : IdentityUser
{
    public string firstName { get; set; } = string.Empty;
    public string lastName { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();
}

