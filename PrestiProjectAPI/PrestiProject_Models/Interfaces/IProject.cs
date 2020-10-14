using System;

namespace PrestiProject_Models.Interfaces
{
    public interface IProject
    {
        string Canceled_or_stoped_cause { get; set; }
        float Cost { get; set; }
        DateTime Finished_Date { get; set; }
        string Progression { get; set; }
        string Project_Title { get; set; }
        DateTime Start_Date { get; set; }
        string Status { get; set; }
        string UID { get; set; }
        string UID_Property { get; set; }
    }
}