using LatinhasLLC.API.Application.DTOs;
using LatinhasLLC.API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LatinhasLLC.API.WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DemandItemsController : ControllerBase
{
    private readonly IDemandItemService _demandItemService;

    public DemandItemsController(IDemandItemService demandItemService)
    {
        _demandItemService = demandItemService;
    }

    [HttpGet]
    public async Task<ActionResult<List<DemandItemDto>>> GetAll()
    {
        var demands = await _demandItemService.GetAllAsync();
        return Ok(demands);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DemandItemDto>> GetById(Guid id)
    {
        var demand = await _demandItemService.GetByIdAsync(id);
        if (demand is null)
            return NotFound();

        return Ok(demand);
    }

    [HttpPost]
    public async Task<ActionResult<DemandItemDto>> Create([FromBody] DemandItemDto dto)
    {
        var created = await _demandItemService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] DemandItemDto dto)
    {
        var updated = await _demandItemService.UpdateAsync(id, dto);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _demandItemService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
