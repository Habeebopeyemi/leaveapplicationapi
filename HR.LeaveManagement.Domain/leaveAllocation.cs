﻿using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain
{
    public class leaveAllocation : BaseDomainEntity
    {
        public int NumberOfDays { get; set; }
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period {  get; set; }
    }
}
