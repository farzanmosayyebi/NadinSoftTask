namespace NadinSoftTask.Core.Dtos.Product;

public record ProductFilterDto(
    string? Name,
    DateOnly? ProduceDate,
    bool? IsAvailable
    //CreatorId
    );
