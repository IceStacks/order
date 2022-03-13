using FluentValidation;
using WebApi.Application.OrderOperations.Commands;

namespace WebApi.Application.OrderOperations.Validators
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Model.UserId).GreaterThan(0);
            RuleFor(x => x.OrderId).GreaterThan(0);
        }
    }
}
