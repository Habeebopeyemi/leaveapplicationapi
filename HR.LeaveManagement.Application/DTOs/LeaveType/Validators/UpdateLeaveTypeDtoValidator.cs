using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDTO>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            Include(new LeaveTypeDtoValidator());

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than zero")
                .LessThanOrEqualTo(int.MaxValue).WithMessage("{PropertyName} is out of range");
        }
    }
}
