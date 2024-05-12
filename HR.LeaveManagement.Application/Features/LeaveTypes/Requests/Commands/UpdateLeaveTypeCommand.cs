using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveTypeDTO leaveTypeDTO {  get; set; }
    }
}
