using FluentValidation;
using WebApi.Application.OrderOperations.Commands;

namespace WebApi.Application.OrderOperations.Validators
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
           
        }
    }
}