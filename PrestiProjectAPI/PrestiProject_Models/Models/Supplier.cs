using System;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Models
{
    public class Supplier : ISupplier
    {
        public string UID { get; set; }
        public string SUP_Name { get; set; }
        public string SUP_Contact_Name { get; set; }
        public string SUP_Phone { get; set; }
        public string SUP_URL { get; set; }
        public string SUP_Email { get; set; }
        public string SUP_Type { get; set; }
        public string UID_Address { get; set; }

    }
}
