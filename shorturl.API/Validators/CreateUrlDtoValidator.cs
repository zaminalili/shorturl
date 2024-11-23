using FluentValidation;
using shorturl.API.Models.Dtos;

namespace shorturl.API.Validators;

public class CreateUrlDtoValidator: AbstractValidator<CreateUrlDto>
{
    public CreateUrlDtoValidator()
    {
        RuleFor(c => c.Url)
            .Must(UrlValidator.IsValidUrl)
            .WithMessage("URL is not in the correct format.");
    }
}
