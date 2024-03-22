namespace NadinSoftTask.Core.Dtos.Product;

public record ProductFilterDto(
    string? Name,
    bool? IsAvailable,
    string? CreatorUserName,
    int? Take,
    int? Skip
    );
