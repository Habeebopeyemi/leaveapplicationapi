using HR.LeaveManagement.Application.DTOs.Common;

namespace HR.LeaveManagement.Application.DTOs.LeaveType
{
    public class LeaveTypeDTO : BaseDTO , ILeaveTypeDTO
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
