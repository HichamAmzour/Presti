using System;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Models
{
    public class Customer : User, ICustomer
    {
        public string CUS_Phone { get; set; }
        public string CUS_Notes { get; set; }
        public string CUS_Notes_2 { get; set; }
        public string CUS_Spouse_First_Name { get; set; }
        public string CUS_Spouse_Last_Name { get; set; }
    }
}
