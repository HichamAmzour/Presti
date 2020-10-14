using System;

namespace PrestiProject_Models.Interfaces
{
    public interface IProduct_Brand
    {
        DateTime BRA_Date { get; set; }
        string BRA_Description { get; set; }
        string BRA_Name { get; set; }
        string UID { get; set; }
    }
}