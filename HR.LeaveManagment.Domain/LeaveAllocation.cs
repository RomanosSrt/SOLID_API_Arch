﻿using HR.LeaveManagment.Domain.Common;

namespace HR.LeaveManagment.Domain;


public class LeaveAllocation : BaseEntity
{
    public int NumberofDays { get; set; }
    public LeaveType? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
}
