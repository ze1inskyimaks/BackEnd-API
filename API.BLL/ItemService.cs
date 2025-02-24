using API.DAL;

namespace API.BLL;

public class ItemService(IItemRepository repository) : IItemService
{
    public Item? GetItem(uint id)
    {
        return repository.GetItem(id);
    }

    public List<Item> GetItemAll()
    {
        return repository.GetItemAll();
    }

    public void SetItem(Item item)
    {
        repository.SetItem(item);
    }

    public void DeleteItem(uint id)
    {
        repository.DeleteItem(id);
    }
}
