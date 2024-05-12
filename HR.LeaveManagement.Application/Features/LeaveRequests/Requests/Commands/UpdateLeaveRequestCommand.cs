using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDTO UpdateLeaveRequestDto { get; set; }

        public ChangeLeaveRequestApprovalDTO ChangeLeaveRequestApprovalDto { get; set;}
    }
}
