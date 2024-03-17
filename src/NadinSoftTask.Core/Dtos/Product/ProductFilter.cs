namespace NadinSoftTask.Core.Dtos.Product;

public record ProductFilter(
    string? Name,
    DateTime? ProduceDate,
    bool? IsAvailable
    //CreatorId
    );
