namespace API.DAL;

public interface IItemRepository
{
    public Task<Item?> GetItem(uint id);
    public Task<List<Item>> GetItemAll(); 
    Task SetItem(Item item);
    Task DeleteItem(uint id);
}