namespace API.DAL;

public class ItemRepository : IItemRepository
{
    private readonly List<Item> _items = new();
    
    public Item? GetItem(uint id)
    {
        return _items.FirstOrDefault(i => i.Id == id);
    }

    public List<Item> GetItemAll()
    {
        return _items;
    }

    public void SetItem(Item item)
    {
        _items.Add(item);
    }

    public void DeleteItem(uint id)
    {
        var item = GetItem(id);
        if (item == null) return;

        _items.Remove(item);
    }
}