using System;

namespace PrestiProject_Models.Interfaces
{
    public interface IEmployee_Work_Details
    {
        DateTime Date { get; set; }
        string UID { get; set; }
        string UID_Employee { get; set; }
        string UID_Project { get; set; }
        int Worked_hours { get; set; }
    }
}