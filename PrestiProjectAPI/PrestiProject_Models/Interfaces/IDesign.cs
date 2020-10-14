using System;

namespace PrestiProject_Models.Interfaces
{
    public interface IDesign
    {
        DateTime Date { get; set; }
        string Description { get; set; }
        string Design_Title { get; set; }
        string UID { get; set; }
    }
}