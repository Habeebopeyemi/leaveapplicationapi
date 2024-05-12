using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDTO>
    {
        public CreateLeaveAllocationDtoValidator() {
            RuleFor(p => p.NumberOfDays)
                .NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than zero")
                .LessThanOrEqualTo(int.MaxValue).WithMessage("{PropertyName} is out of range");

            RuleFor(p => p.LeaveTypeId)
                .NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than zero")
                .LessThanOrEqualTo(int.MaxValue).WithMessage("{PropertyName} is out of range");

            RuleFor(p => p.Period)
                .NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than zero")
                .LessThanOrEqualTo(int.MaxValue).WithMessage("{PropertyName} is out of range");
        }
    }
}
