using LatinhasLLC.API.Application.DTOs;
using LatinhasLLC.API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LatinhasLLC.API.WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DemandsController : ControllerBase
{
    private readonly IDemandService _demandService;

    public DemandsController(IDemandService demandService)
    {
        _demandService = demandService;
    }

    // 🔹 GET: api/demands
    [HttpGet]
    public async Task<ActionResult<List<DemandDto>>> GetAll()
    {
        var demands = await _demandService.GetAllAsync();
        return Ok(demands);
    }

    // 🔹 GET: api/demands/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DemandDto>> GetById(Guid id)
    {
        var demand = await _demandService.GetByIdAsync(id);
        if (demand is null)
            return NotFound();

        return Ok(demand);
    }

    // 🔹 POST: api/demands
    [HttpPost]
    public async Task<ActionResult<DemandDto>> Create([FromBody] DemandDto dto)
    {
        var created = await _demandService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // 🔹 PUT: api/demands/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] DemandDto dto)
    {
        var updated = await _demandService.UpdateAsync(id, dto);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    // 🔹 DELETE: api/demands/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _demandService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
