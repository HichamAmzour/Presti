using System;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Models
{
    public class Employee_Work_Details : IEmployee_Work_Details
    {
        public string UID { get; set; }
        public DateTime Date { get; set; }
        public int Worked_hours { get; set; }
        public string UID_Project { get; set; }
        public string UID_Employee { get; set; }
    }
}
