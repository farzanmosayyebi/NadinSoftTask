namespace NadinSoftTask.Core.Dtos.Product;

public record ProductCreate(
    string Name,
    DateOnly ProduceDate,
    string ManufacturerEmail,
    string ManufacturerPhone,
    bool IsAvailable
    );
