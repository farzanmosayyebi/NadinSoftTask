namespace NadinSoftTask.Core.Dtos.Product;

public record ProductCreate(
    string Name,
    DateTime ProduceDate,
    string ManufacturerEmail,
    string ManufacturerPhone,
    bool IsAvailable
    );
