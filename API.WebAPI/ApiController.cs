using API.BLL;
using API.DAL;
using Microsoft.AspNetCore.Mvc;

namespace API.WebAPI;

[ApiController]
[Route("items")]
public class ApiController : ControllerBase
{ 
    private readonly IItemService _itemService;
    private readonly IUserService _userService;

    public ApiController(IItemService itemService, IUserService userService)
    {
        _itemService = itemService;
        _userService = userService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetItem(uint id)
    {
        var item = await _itemService.GetItem(id);
        if (item == null)
        {
            return NotFound(new {message = $"Can`t found item for {id}id!"});
        }

        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> SetItem([FromBody] Item item)
    {
        await _itemService.SetItem(item);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteItem(uint id)
    {
        await _itemService.DeleteItem(id);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]User user)
    {
        var success = await _userService.Login(user);

        if (success == null)
        {
            return NotFound();
        }

        return Ok(success);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]User user)
    {
        await _userService.Register(user);
        return Ok();
    }
}