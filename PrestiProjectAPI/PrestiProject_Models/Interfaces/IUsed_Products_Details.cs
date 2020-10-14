using System;

namespace PrestiProject_Models.Interfaces
{
    public interface IUsed_Products_Details
    {
        int Damaged_numb { get; set; }
        DateTime Date { get; set; }
        int Qte { get; set; }
        string UID { get; set; }
        string UID_PRO { get; set; }
        string UID_Project { get; set; }
    }
}