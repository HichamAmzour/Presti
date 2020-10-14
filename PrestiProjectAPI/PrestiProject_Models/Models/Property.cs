using System;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Models
{
    public class Property : IProperty
    {
        public string UID { get; set; }
        public string PRO_Name { get; set; }
        public string PRO_Lot_Number { get; set; }
        public string Parts_To_Build { get; set; }
        public string Description { get; set; }
        public float  Size { get; set; }
        public string Size_Unit { get; set; }
        public DateTime Construction_Date { get; set; }
        public string PRO_UID_Type { get; set; }
        public string PRO_UID_Customer { get; set; }
        public string UID_Address { get; set; }
    }
}
