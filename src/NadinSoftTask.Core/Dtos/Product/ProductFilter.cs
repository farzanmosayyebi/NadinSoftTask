namespace NadinSoftTask.Core.Dtos.Product;

public record ProductFilter(
    string? Name,
    DateOnly? ProduceDate,
    bool? IsAvailable
    //CreatorId
    );
