using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data;
using ShoppingListApp.Interfaces;
using ShoppingListApp.Models;

namespace ShoppingListApp.Services;

public class ShoppingListService : IShoppingListService
{
    private readonly ApplicationDbContext _context;
    public ShoppingListService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Create(ShoppingList list)
    {
        _context.ShoppingLists.Add(list);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var list = await _context.ShoppingLists.FindAsync(id);
        if (list == null) { 
            return;
        }
        _context.ShoppingLists.Remove(list);
        await _context.SaveChangesAsync();
    }

    public async Task<ShoppingList?> GetById(int id)
    {
        return await _context.ShoppingLists
            .Include(x => x.Items)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<ShoppingList>> GetListsForUser(string userId)
    {
        return await _context.ShoppingLists
            .Where(x => x.userId == userId)
            .Include(i => i.Items)
            .ToListAsync();
    }

    public async Task Update(ShoppingList list)
    {
        _context.Update(list);
        await _context.SaveChangesAsync();
    }
}
