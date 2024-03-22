namespace NadinSoftTask.Core.Dtos.Product;

public record ProductDetailsDto(
    string Name,
    DateOnly ProduceDate,
    string ManufacturerEmail,
    string ManufacturerPhone,
    bool IsAvailable
    );
