using API.DAL;

namespace API.BLL;

public class ItemService(IItemRepository repository) : IItemService
{
    public async Task<Item?> GetItem(uint id)
    {
        return await repository.GetItem(id);
    }

    public async Task<List<Item>> GetItemAll()
    {
        return await repository.GetItemAll();
    }

    public async Task SetItem(Item item)
    {
        await repository.SetItem(item);
    }

    public async Task DeleteItem(uint id)
    {
        await repository.DeleteItem(id);
    }
}
