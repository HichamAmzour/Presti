using PrestiProject_Models.Interfaces;
using System;

namespace PrestiProject_Models.Models
{
    public class Company : ICompany
    {
        public string UID { get; set; }
        public string COM_Name { get; set; }
        public string COM_TPS { get; set; }
        public string COM_TVQ { get; set; }
        public string COM_RBQ { get; set; }
        public string COM_NEQ { get; set; }
        public string COM_GCR { get; set; }
        public string UID_Address { get; set; }
    }
}
