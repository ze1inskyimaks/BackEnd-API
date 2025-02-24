using API.DAL;

namespace API.BLL;

public interface IItemService
{
    public Item? GetItem(uint id);
    public List<Item> GetItemAll(); 
    void SetItem(Item item);
    void DeleteItem(uint id);
}