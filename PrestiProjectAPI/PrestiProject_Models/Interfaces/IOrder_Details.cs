using System;

namespace PrestiProject_Models.Interfaces
{
    public interface IOrder_Details
    {
        DateTime Date { get; set; }
        string UID { get; set; }
        string UID_Customer { get; set; }
        string UID_Design { get; set; }
    }
}