using System;

namespace PrestiProject_Models.Interfaces
{
    public interface IProduct_Command
    {
        DateTime Date { get; set; }
        string UID { get; set; }
        string UID_Supplier { get; set; }
    }
}