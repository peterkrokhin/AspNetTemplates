using FluentValidation;

namespace TodoApiWithMediatr.Services
{
    public class DeleteTodoItemCommandValidator : AbstractValidator<DeleteTodoItemCommand>
    {
        public DeleteTodoItemCommandValidator()
        {
            RuleFor(d => d.Id).NotNull().GreaterThan(0);
        }
    }
}