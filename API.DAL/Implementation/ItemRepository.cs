using Microsoft.EntityFrameworkCore;

namespace API.DAL;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _context;

    public ItemRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Item?> GetItem(uint id)
    {
        return await _context.Items.FindAsync(id);
    }

    public async Task<List<Item>> GetItemAll()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task SetItem(Item item)
    {
        await _context.Items.AddAsync(item);    
        await _context.SaveChangesAsync();  
    }

    public async Task DeleteItem(uint id)
    {
        var item = await GetItem(id);
        if (item == null) return;

        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
    }
}