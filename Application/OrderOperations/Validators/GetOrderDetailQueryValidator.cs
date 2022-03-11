using FluentValidation;
using WebApi.Application.OrderOperations.Commands;

namespace WebApi.Application.OrderOperations.Validators
{
    public class GetOrderDetailQueryValidator : AbstractValidator<GetOrderDetailQuery>
    {
        public GetOrderDetailQueryValidator()
        {
            RuleFor(x => x.OrderId).GreaterThan(0);
        }
    }
}
