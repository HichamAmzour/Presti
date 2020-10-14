using System;

namespace PrestiProject_Models.Interfaces
{
    public interface IProperty
    {
        DateTime Construction_Date { get; set; }
        string Description { get; set; }
        string Parts_To_Build { get; set; }
        string PRO_Lot_Number { get; set; }
        string PRO_Name { get; set; }
        string PRO_UID_Customer { get; set; }
        string PRO_UID_Type { get; set; }
        float Size { get; set; }
        string Size_Unit { get; set; }
        string UID { get; set; }
        string UID_Address { get; set; }
    }
}