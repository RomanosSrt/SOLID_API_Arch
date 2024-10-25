using HR.LeaveManagement.Persistence.DatabaseContext;
using HR.LeaveManagment.Domain;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HR.LeaveManagement.Persistence.IntegrationTests
{
    public class HrDataBaseContextTests
    {
        private HrDatabaseContext _hrDatabaseContext;

        public HrDataBaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<HrDatabaseContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _hrDatabaseContext = new HrDatabaseContext(dbOptions);
        }


        [Fact]
        public async Task Save_DateCreatedValueAsync()
        {
            //Arrange
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation"
            };

            //Act

            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            //Assert

            leaveType.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async Task Save_DateModifiedValueAsync()
        {
            //Arrange
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation"
            };

            //Act

            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            //Assert

            leaveType.DateModified.ShouldNotBeNull();
        }

    }
}