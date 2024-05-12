using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<UpdateLeaveTypeDTO>
    {
        public CreateLeaveTypeDtoValidator()
        {
            Include(new LeaveTypeDtoValidator());
        }
    }
}
