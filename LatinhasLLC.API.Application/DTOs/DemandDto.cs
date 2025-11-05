namespace LatinhasLLC.API.Application.DTOs;

public record DemandDto(
    Guid Id,
    DateTime StartDate,
    DateTime EndDate,
    string Status,
    IEnumerable<ItemDto> Items
);