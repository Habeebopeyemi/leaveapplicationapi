using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDTO>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;

            Include(new LeaveRequestDtoValidator(_leaveRequestRepository));

            RuleFor(p => p.LeaveTypeId)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
