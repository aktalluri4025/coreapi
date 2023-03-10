using FluentValidation;

namespace Corewebapi.Validators
{
    public class UpdateWalkRequestValidator:AbstractValidator<Models.DTO.UpdateWalkRequest>
    {
        public UpdateWalkRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThanOrEqualTo(0);                }
    }
}
