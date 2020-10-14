using System;

namespace PrestiProject_Models.Interfaces
{
    public interface IProduct_Stock
    {
        int Current_Qte { get; set; }
        DateTime Date { get; set; }
        int Init_Qte { get; set; }
        string Product_UID { get; set; }
        string Status { get; set; }
        string UID { get; set; }
    }
}