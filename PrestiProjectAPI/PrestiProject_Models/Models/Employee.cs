using PrestiProject_Models.Interfaces;
using System;


namespace PrestiProject_Models.Models
{
    public class Employee : User, IEmployee
    {
        public string EMP_Last_Login_Date   { get; set; }
        public string EMP_Employee_Number   { get; set; }
        public string EMP_Employee_Service  { get; set; }
        public string EMP_Phone             { get; set; }
        public string EMP_Extension_Number  { get; set; }
    }
}
