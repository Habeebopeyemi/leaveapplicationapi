using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveAllocationDTO leaveAllocationDTO { get; set; }
    }
}
