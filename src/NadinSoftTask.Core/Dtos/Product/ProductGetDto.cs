namespace NadinSoftTask.Core.Dtos.Product;

public record ProductGetDto(
    int Id,
    string Name,
    DateOnly ProduceDate,
    string ManufacturerEmail,
    string ManufacturerPhone,
    bool IsAvailable,
    string CreatorId
    );
