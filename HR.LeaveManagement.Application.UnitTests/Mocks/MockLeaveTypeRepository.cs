using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagment.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Mocks;

public class MockLeaveTypeRepository
{
    public static Mock<ILeaveTypeRepository> GetLeaveTypes()
    {
        var leaveTypes = new List<LeaveType>
        {
            new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation"
            },
            new LeaveType
            {
                Id = 2,
                DefaultDays = 20,
                Name = "Test Sick Leave"
            },
            new LeaveType
            {
                Id = 3,
                DefaultDays = 90,
                Name = "Test Maternity Leave"
            }
        };

        var mockRepo = new Mock<ILeaveTypeRepository>();

        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(leaveTypes);

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveType>()))
            .Returns((LeaveType leaveType) => {
                leaveTypes.Add(leaveType);
                return Task.CompletedTask;
            });

        return mockRepo;
    }
}
