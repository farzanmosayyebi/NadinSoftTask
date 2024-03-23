using FluentValidation;
using NadinSoftTask.Core.Dtos.Product;

namespace NadinSoftTask.Application.Validators.Product;

public class ProductUpdateValidator : AbstractValidator<ProductUpdateDto>
{
    public ProductUpdateValidator()
    {
        RuleFor(input => input.ProduceDate).NotEmpty()
            .Must(input => input.CompareTo(DateOnly.FromDateTime(DateTime.Today.Date)) <= 0);

        RuleFor(input => input.ManufacturerEmail).NotEmpty().EmailAddress();

        RuleFor(input => input.ManufacturerPhone).NotEmpty()
            .Matches("^0\\d{2}-\\d{8}$"); // example: 021-12345678

        RuleFor(input => input.Name).NotEmpty().MaximumLength(255);
    }
}
