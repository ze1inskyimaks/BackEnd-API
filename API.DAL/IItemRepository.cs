namespace API.DAL;

public interface IItemRepository
{
    public Item? GetItem(uint id);
    public List<Item> GetItemAll(); 
    void SetItem(Item item);
    void DeleteItem(uint id);
}