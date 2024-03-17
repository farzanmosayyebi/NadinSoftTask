namespace NadinSoftTask.Core.Dtos.Product;

public record ProductUpdate(
    int Id,
    string Name,
    DateTime ProduceDate,
    string ManufacturerEmail,
    string ManufacturerPhone,
    bool IsAvailable
    );
