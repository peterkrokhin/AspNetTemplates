using FluentValidation;

namespace TodoApiWithMediatr.Services
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(c => c.Name).NotNull().Length(2, 20);
            RuleFor(c => c.isCompleted).NotNull();
            RuleFor(c => c.Description).NotNull().Length(2, 100);
        }
    }
}