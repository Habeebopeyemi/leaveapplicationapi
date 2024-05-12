using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailsRequest : IRequest<LeaveTypeDTO>
    {
        public int Id {  get; set; }
    }
}
