using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class LeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public LeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository) {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.NumberOfDays)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
                .LessThan(30).WithMessage("{PropertyName} must be less than {ComparisonValue}.");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                    var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                    return !leaveTypeExists;
                }).WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.Period)
                .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");
        }
    }
}
