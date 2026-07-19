using ShoppingListApp.Models;

namespace ShoppingListApp.Interfaces;

public interface IShoppingListService
{
    Task<IEnumerable<ShoppingList>> GetListsForUser(string userId);

    Task<ShoppingList?> GetById(int id);

    Task Create(ShoppingList list);

    Task Update(ShoppingList list);

    Task Delete(int id);
}