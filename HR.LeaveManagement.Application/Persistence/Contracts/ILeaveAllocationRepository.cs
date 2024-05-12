using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<leaveAllocation>
    {
        Task<leaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<leaveAllocation>> GetLeaveAllocationsWithDetails();
    }
}
