using FluentValidation;
using WebApi.Application.OrderOperations.Commands;

namespace WebApi.Application.OrderOperations.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
           RuleFor(x => x.Model.UserId).GreaterThan(0);
           RuleFor(x => x.Model.ItemIds.Length).GreaterThan(0);
        }
    }
}
