using API.DAL;

namespace API.BLL;

public interface IItemService
{
    public Task<Item?> GetItem(uint id);
    public Task<List<Item>> GetItemAll(); 
    Task SetItem(Item item);
    Task DeleteItem(uint id);
}