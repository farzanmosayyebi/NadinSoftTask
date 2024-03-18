namespace NadinSoftTask.Core.Dtos.Product;

public record ProductGet(
    int Id,
    string Name,
    DateOnly ProduceDate,
    string ManufacturerEmail,
    string ManufacturerPhone,
    bool IsAvailable,
    int CreatorId
    );
