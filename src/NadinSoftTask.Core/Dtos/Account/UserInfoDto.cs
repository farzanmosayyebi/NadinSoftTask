using NadinSoftTask.Core.Dtos.Product;

namespace NadinSoftTask.Core.Dtos.Account;

public record UserInfoDto(
    Guid Id,
    string UserName,
    string Email,
    List<ProductGetDto> CreatedProducts);


