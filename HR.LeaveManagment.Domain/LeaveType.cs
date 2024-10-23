using HR.LeaveManagment.Domain.Common;

namespace HR.LeaveManagment.Domain;


public class LeaveType : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public int DefaultDays { get; set; }

}
