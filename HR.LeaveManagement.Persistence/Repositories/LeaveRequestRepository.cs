using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HRLeaveManagementDbContext _dbContext;
        public LeaveRequestRepository(HRLeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
