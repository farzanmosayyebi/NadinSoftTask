namespace NadinSoftTask.Core.Dtos.Product;

public record ProductCreateDto(
    string Name,
    DateOnly ProduceDate,
    string ManufacturerEmail,
    string ManufacturerPhone,
    bool IsAvailable,
    string CreatorId
    );
