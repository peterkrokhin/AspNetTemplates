using FluentValidation;

namespace TodoApiCQRS.Services
{
    public class PutTodoItemCommandValidator : AbstractValidator<PutTodoItemCommand>
    {
        public PutTodoItemCommandValidator()
        {
            RuleFor(p => p.Id).NotNull().GreaterThan(0);
            RuleFor(p => p.Name).NotNull().Length(2, 20);
            RuleFor(p => p.isCompleted).NotNull();
            RuleFor(p => p.Description).NotNull().Length(2, 100);
        }
    }
}