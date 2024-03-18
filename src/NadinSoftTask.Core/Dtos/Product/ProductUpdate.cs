namespace NadinSoftTask.Core.Dtos.Product;

public record ProductUpdate(
    int Id,
    string Name,
    DateOnly ProduceDate,
    string ManufacturerEmail,
    string ManufacturerPhone,
    bool IsAvailable
    );
