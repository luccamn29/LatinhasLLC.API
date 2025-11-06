using LatinhasLLC.API.Application.DTOs;
using LatinhasLLC.API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LatinhasLLC.API.WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ItemDto>>> GetAll()
    {
        var items = await _itemService.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{sku}")]
    public async Task<ActionResult<ItemDto>> GetById(string sku)
    {
        var item = await _itemService.GetBySKUAsync(sku);
        if (item is null)
            return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<ItemDto>> Create([FromBody] ItemDto dto)
    {
        var created = await _itemService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.SKU }, created);
    }

    [HttpPut("{sku}")]
    public async Task<IActionResult> Update(string sku, [FromBody] ItemDto dto)
    {
        var updated = await _itemService.UpdateAsync(sku, dto);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{sku}")]
    public async Task<IActionResult> Delete(string sku)
    {
        var deleted = await _itemService.DeleteAsync(sku);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
