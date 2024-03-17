namespace NadinSoftTask.Core.Dtos.Product;

public record ProductGet(
    int Id,
    string Name,
    DateTime ProduceDate,
    string ManufacturerEmail,
    string ManufacturerPhone,
    bool IsAvailable
    );
