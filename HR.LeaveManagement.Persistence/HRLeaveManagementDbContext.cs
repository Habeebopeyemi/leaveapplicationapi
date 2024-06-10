using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence
{
    public class HRLeaveManagementDbContext : DbContext
    {
        public HRLeaveManagementDbContext(DbContextOptions<HRLeaveManagementDbContext> options )
            : base( options )
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly( typeof( HRLeaveManagementDbContext ).Assembly );
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.UtcNow;

                if(entry.State == EntityState.Added )
                {
                    entry.Entity.DateCreated = DateTime.UtcNow; 
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<leaveAllocation> LeaveAllocations { get; set; }
    }
}
