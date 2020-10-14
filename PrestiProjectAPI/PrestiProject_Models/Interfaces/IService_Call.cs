using System;

namespace PrestiProject_Models.Interfaces
{
    public interface IService_Call
    {
        string Call_Description { get; set; }
        string Caller_Info { get; set; }
        DateTime Date_time { get; set; }
        string UID { get; set; }
        string UID_Customer { get; set; }
    }
}