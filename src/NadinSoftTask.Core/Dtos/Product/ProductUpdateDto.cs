namespace NadinSoftTask.Core.Dtos.Product;

public record ProductUpdateDto(
    int Id,
    string Name,
    DateOnly ProduceDate,
    string ManufacturerEmail,
    string ManufacturerPhone,
    bool IsAvailable
    );
