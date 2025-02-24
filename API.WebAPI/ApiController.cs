using API.BLL;
using API.DAL;
using Microsoft.AspNetCore.Mvc;

namespace API.WebAPI;

[ApiController]
[Route("api/items")]
public class ApiController : ControllerBase
{ 
    private readonly IItemService _itemService;

    public ApiController(IItemService itemService) 
    {
            _itemService = itemService;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetItem(uint id)
    {
        var item = _itemService.GetItem(id);
        if (item == null)
        {
            return NotFound(new {message = $"Can`t found item for {id}id!"});
        }

        return Ok(item);
    }

    [HttpPost]
    public IActionResult SetItem([FromBody] Item item)
    {
        _itemService.SetItem(item);
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteItem(uint id)
    {
        _itemService.DeleteItem(id);
        return Ok();
    }
}